using ReactApp1.Server.DBModels.Files;
using ReactApp1.Server.DBModels.Trash;
using ReactApp1.Server.DBModels.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.DBModels.Folders
{
	[Table("Folder")]
	public class FolderEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string FolderName { get; set; }
		public int? ParentFolderId { get; set; }
		public FolderEntity? ParentFolder { get; set; }
		public int userId { get; set; }
		public UsersEntity Users { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ICollection<FolderEntity>? folderEntities { get; set; }
		public ICollection<FileEntity>? Files { get; set; }
		public ICollection<TrashEntity>? TrashEntities { get; set; }
	}
}
