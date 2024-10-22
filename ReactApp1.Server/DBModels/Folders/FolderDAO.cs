using ReactApp1.Server.DBModels.Context;
using ReactApp1.Server.Helper;
using ReactApp1.Server.RBModels.Folder;

namespace ReactApp1.Server.DBModels.Folders
{
	public interface IFolder
	{
		public FolderEntity CreateFolder(FolderRB folderRB);
		public FolderEntity GetFolder(FolderSRB srb);
		public FolderEntity delFolder(FolderSRB rb);
		public List<FolderEntity> GetAllFolders();
	}
	public class FolderDAO : IFolder
	{
		public readonly new ApplicationDBFactory _dbcontext;
		public readonly IHelper _helper;

		public FolderDAO(ApplicationDBFactory dbcontext, IHelper helper)
		{
			_dbcontext = dbcontext;
			_helper = helper;
		}
		public FolderEntity CreateFolder(FolderRB folderRB)
		{
			try
			{
				FolderEntity entity = new FolderEntity
				{
					FolderName = folderRB.FolderName,
					ParentFolderId = folderRB.ParentFolderId,
					userId = folderRB.userId,
				};

				_dbcontext.folders.Add(entity);
				_dbcontext.SaveChanges();
				return entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		public FolderEntity GetFolder(FolderSRB srb)
		{
			try
			{
				IQueryable<FolderEntity> query = _dbcontext.folders.AsQueryable();
				return _helper.Search(query, srb).ToList()[0];
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		public FolderEntity delFolder(FolderSRB rb)
		{
			try
			{
				IQueryable<FolderEntity> query = _dbcontext.folders.AsQueryable();
				FolderEntity entity = _helper.Search(query, rb).ToList()[0];
				_dbcontext.folders.Remove(entity);
				_dbcontext.SaveChanges();
				return entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		public List<FolderEntity> GetAllFolders()
		{
			try
			{
				FolderSRB srb = new FolderSRB();
				IQueryable<FolderEntity> query = _dbcontext.folders.AsQueryable();
				return _helper.Search(query, srb).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
	}
}
