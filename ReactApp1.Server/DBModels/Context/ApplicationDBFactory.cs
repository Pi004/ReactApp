using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.DBModels.Files;
using ReactApp1.Server.DBModels.Folders;
using ReactApp1.Server.DBModels.Trash;
using ReactApp1.Server.DBModels.Users;

namespace ReactApp1.Server.DBModels.Context
{
	public class ApplicationDBFactory : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\LOCALHOST;Database=DriveClone;User Id=sa;Password=root@123;TrustServerCertificate=true;MultipleActiveResultSets=True;");
		}

		public DbSet<UsersEntity> users { get; set; }
		public DbSet<FolderEntity> folders { get; set; }
		public DbSet<FileEntity> files { get; set; }
		public DbSet<TrashEntity> trash { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FolderEntity>()
				.HasOne(p => p.Users)
				.WithMany(p => p.Folders)
				.HasForeignKey(p => p.userId);

			modelBuilder.Entity<FolderEntity>()
				.HasOne(p => p.ParentFolder)
				.WithMany(p => p.folderEntities)
				.HasForeignKey(p => p.ParentFolderId);

			modelBuilder.Entity<FileEntity>()
				.HasOne(p => p.Folder)
				.WithMany(p => p.Files)
				.HasForeignKey(p => p.folderId);

			modelBuilder.Entity<FileEntity>()
				.HasOne(p => p.User)
				.WithMany(p => p.Files)
				.HasForeignKey(p => p.userId);

			modelBuilder.Entity<TrashEntity>()
				.HasOne(p => p.User)
				.WithMany(p => p.trashEntities)
				.HasForeignKey(p => p.UserId);

			modelBuilder.Entity<TrashEntity>()
				.HasOne(p => p.Folder)
				.WithMany(p => p.TrashEntities)
				.HasForeignKey(p => p.FolderId);

			modelBuilder.Entity<TrashEntity>()
				.HasOne(p => p.File)
				.WithOne(p => p.Trash)
				.HasForeignKey<TrashEntity>(p => p.FileId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
