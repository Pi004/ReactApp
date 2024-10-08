using ReactApp1.Server.DBModels.Folders;
using ReactApp1.Server.DBModels.Trash;
using ReactApp1.Server.DBModels.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.DBModels.Files
{
	[Table("files")]
	public class FileEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string fileName { get; set; }
		public int userId { get; set; }
		public UsersEntity User { get; set; }
		public int? folderId { get; set; }
		public FolderEntity? Folder { get; set; }
		public string fileType { get; set; }
		public int filesize { get; set; }
		public string filePath { get; set; }
		public byte[] fileData { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public TrashEntity? Trash { get; set; }
	}
}
