using Microsoft.AspNetCore.Identity;
using ReactApp1.Server.DBModels.Users;
using ReactApp1.Server.RBModels.Users;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace ReactApp1.Server.Helper
{
	public interface IHelper
	{
		public IQueryable<T> Search<T>(IQueryable<T> query, object frb);
		public void PasswordHash(UsersEntity user, UserRB rb);
		public bool VerifyPasswrod(UsersEntity user, UserRB rb);
	}
	public class Helper : IHelper
	{
		//private readonly ApplicationDBFactory _DbContext;
		private readonly PasswordHasher<UsersEntity> _passwordHasher;
		public Helper(/*ApplicationDBFactory dbContext,*/ PasswordHasher<UsersEntity> passwordHasher)
		{
			//_DbContext = dbContext;
			_passwordHasher = passwordHasher;
		}
		public IQueryable<T> Search<T>(IQueryable<T> query, object rb)
		{
			PropertyInfo[] properties = rb.GetType().GetProperties();
			List<string> columns = new List<string>();
			foreach (PropertyInfo property in properties)
			{
				object? value = property.GetValue(rb);
				if (value == null)
				{
					continue;
				}
				if (value.GetType() == typeof(string) || value.GetType() == typeof(int))
				{
					query = query.Where($"{property.Name} == @0", value);
				}
			}
			return query;
		}
		public void PasswordHash(UsersEntity user, UserRB rb)
		{
			string password = rb.Password;
			user.PasswordHash = _passwordHasher.HashPassword(user, password);
		}
		public bool VerifyPasswrod(UsersEntity user, UserRB rb)
		{
			string password = rb.Password;
			PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
			return result == PasswordVerificationResult.Success;
		}
	}
}
