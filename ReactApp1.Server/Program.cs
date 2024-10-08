using Microsoft.AspNetCore.Identity;
using ReactApp1.Server.DBModels.Context;
using ReactApp1.Server.DBModels.Users;
using ReactApp1.Server.Helper;
using ReactApp1.Server.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UsersServices>();
builder.Services.AddScoped<IUsers, UsersDAO>();
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddDbContext<ApplicationDBFactory>();
builder.Services.AddScoped<PasswordHasher<UsersEntity>>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
