using ReactApp1.Server.DBModels.Folders;
using ReactApp1.Server.DTO;
using ReactApp1.Server.Helper;
using ReactApp1.Server.RBModels.Folder;

namespace ReactApp1.Server.Services.Folder
{
	public interface IFolderService
	{
		public ResponseDTO CreateFolder(FolderRB rb);
		public ResponseDTO DeleteFolder(FolderSRB rb);
		public ResponseDTO GetFolder(FolderSRB rb);
		public ResponseDTO GetAllFolder();
	}
	public class FolderService : IFolderService
	{
		private readonly IFolder _folder;
		public readonly IHelper helper;
		public ResponseDTO response = new ResponseDTO { };
		public FolderService(IFolder folder, IHelper Helper)
		{
			_folder = folder;
			helper = Helper;
		}

		public ResponseDTO CreateFolder(FolderRB rb)
		{
			try
			{
				response.data = _folder.CreateFolder(rb);
				return response;
			}
			catch (Exception ex)
			{
				response.data = ex;
				return response;
			}
		}
		public ResponseDTO DeleteFolder(FolderSRB rb)
		{
			try
			{
				response.data = _folder.delFolder(rb);
				return response;
			}
			catch (Exception ex)
			{
				response.data = ex;
				return response;
			}
		}
		public ResponseDTO GetFolder(FolderSRB rb)
		{
			try
			{
				response.data = _folder.GetFolder(rb);
				return response;
			}
			catch (Exception ex)
			{
				response.data = ex;
				return response;
			}
		}
		public ResponseDTO GetAllFolder()
		{
			try
			{
				response.data = _folder.GetAllFolders();
				return response;
			}
			catch (Exception ex)
			{
				response.data = ex;
				return response;
			}
		}
	}
}
