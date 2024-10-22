using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.DTO;
using ReactApp1.Server.RBModels.Folder;
using ReactApp1.Server.Services.Folder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactApp1.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FolderController : ControllerBase
	{
		public readonly IFolderService _folderService;
		public ResponseDTO response = new ResponseDTO { };
		public FolderController(IFolderService folderService)
		{
			_folderService = folderService;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				return Ok(_folderService.GetAllFolder());
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return BadRequest(response);
			}
		}
		[HttpGet("folderName")]
		public IActionResult GetFolder([FromBody] FolderSRB folder)
		{
			try
			{
				return Ok(_folderService.GetFolder(folder));
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return BadRequest(response);
			}
		}
		[HttpPost]
		public IActionResult AddFolder([FromBody] FolderRB folder)
		{
			try
			{
				return Ok(_folderService.CreateFolder(folder));
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return BadRequest(response);
			}
		}
		[HttpDelete]
		public IActionResult Delete([FromBody] FolderSRB folder)
		{
			try
			{
				return Ok(_folderService.DeleteFolder(folder));
			}
			catch (Exception ex)
			{
				response.data = ex.ToString();
				return BadRequest(response);
			}
		}
	}
}
