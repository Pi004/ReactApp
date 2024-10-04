using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.DTO;
using ReactApp1.Server.RBModels.Users;
using ReactApp1.Server.Services.Users;


namespace ReactApp1.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public readonly IUserService UserService;
		public ResponseDTO response = new ResponseDTO { };
		public UserController(IUserService userService)
		{
			UserService = userService;
		}

		[HttpGet]
		public ResponseDTO GetAll()
		{
			try
			{
				return UserService.Read();
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return response;
			}
		}

		[HttpPost]
		public ResponseDTO Post([FromBody] UserRB rb)
		{
			try
			{
				return UserService.Create(rb);
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return response;
			}
		}

		[HttpDelete]
		public ResponseDTO Delete([FromBody] DelUserRB rb)
		{
			try
			{
				return UserService.Delete(rb);
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return response;
			}
		}
	}
}
