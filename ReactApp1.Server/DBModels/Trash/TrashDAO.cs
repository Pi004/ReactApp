using ReactApp1.Server.DBModels.Context;
using ReactApp1.Server.DBModels.Files;
using ReactApp1.Server.DBModels.Folders;
using ReactApp1.Server.Helper;

namespace ReactApp1.Server.DBModels.Trash
{
	public interface ITrash
	{
		public TrashEntity? DeleteFile(FileEntity file);
		public TrashEntity? DeleteFolder(FolderEntity folder);
	}
	public class TrashDAO : ITrash
	{
		private readonly new ApplicationDBFactory _dbcontext;
		private readonly IHelper _helper;

		public TrashDAO(ApplicationDBFactory dbcontext, IHelper helper)
		{
			_dbcontext = dbcontext;
			_helper = helper;
		}

		public TrashEntity? DeleteFile(FileEntity file)
		{
			try
			{
				TrashEntity entity = new TrashEntity
				{
					UserId = file.userId,
					FolderId = file.folderId,
					FileId = file.Id,
				};
				_dbcontext.trash.Add(entity);
				_dbcontext.SaveChanges();
				return entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		public TrashEntity? DeleteFolder(FolderEntity folder)
		{
			try
			{
				TrashEntity entity = new TrashEntity
				{
					UserId = folder.userId,
					FolderId = folder.Id,
				};
				_dbcontext.trash.Add(entity);
				_dbcontext.SaveChanges();
				return entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
	}
}
