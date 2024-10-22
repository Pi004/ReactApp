using ReactApp1.Server.DBModels.Context;
using ReactApp1.Server.Helper;

namespace ReactApp1.Server.DBModels.Folders
{
	public interface IFolder
	{

	}
	public class FolderDAO : IFolder
	{
		public readonly new ApplicationDBFactory _dbcontext;
		public readonly IHelper _helper;

	}
}
