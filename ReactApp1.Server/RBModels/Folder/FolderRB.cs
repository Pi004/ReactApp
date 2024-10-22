namespace ReactApp1.Server.RBModels.Folder
{
	public class FolderRB
	{
		public FolderRB() { }
		public string FolderName { get; set; }
		public int? ParentFolderId { get; set; } = null;
		public int userId { get; set; }
	}
}
