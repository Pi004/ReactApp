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
		public IActionResult GetAll()
		{
			try
			{
				return Ok(UserService.Read());
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return Ok(response);
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody] UserRB rb)
		{
			try
			{
				return Ok(UserService.Create(rb));
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return Ok(response);
			}
		}

		[HttpDelete]
		public IActionResult Delete([FromBody] DelUserRB rb)
		{
			try
			{
				return Ok(UserService.Delete(rb));
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return Ok(response);
			}
		}
	}
}
