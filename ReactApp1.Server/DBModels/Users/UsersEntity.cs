using ReactApp1.Server.DBModels.Files;
using ReactApp1.Server.DBModels.Folders;
using ReactApp1.Server.DBModels.Trash;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp1.Server.DBModels.Users
{
	[Table("users")]
	public class UsersEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ICollection<FolderEntity>? Folders { get; set; }
		public ICollection<FileEntity>? Files { get; set; }
		public ICollection<TrashEntity>? trashEntities { get; set; }
	}
}
