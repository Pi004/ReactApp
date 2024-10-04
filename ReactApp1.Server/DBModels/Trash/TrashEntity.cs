using ReactApp1.Server.DBModels.Files;
using ReactApp1.Server.DBModels.Folders;
using ReactApp1.Server.DBModels.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.DBModels.Trash
{
	[Table("Trash")]
	public class TrashEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int UserId { get; set; }
		public UsersEntity User { get; set; }
		public int? FolderId { get; set; }
		public FolderEntity? Folder { get; set; }
		public int? FileId { get; set; }
		public FileEntity? File { get; set; }
		public DateTime deletedAt { get; set; }
	}
}
