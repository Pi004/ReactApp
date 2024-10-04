using ReactApp1.Server.DBModels.Context;
using ReactApp1.Server.DBModels.Trash;
using ReactApp1.Server.RBModels.Users;

namespace ReactApp1.Server.DBModels.Users
{
	public interface IUsers
	{
		public UsersEntity CreateUser(UserRB rb);
		public void DeleteUser(UserRB rb);
		public List<UsersEntity> ReadUsers();
	}
	public class UsersDAO : IUsers
	{
		public readonly new ApplicationDBFactory _dbcontext;


		public UsersDAO(ApplicationDBFactory dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public UsersEntity CreateUser(UserRB rb)
		{
			UsersEntity entity = new UsersEntity
			{
				Email = rb.Email,
				PasswordHash = rb.PasswordHash,
				UserName = rb.UserName,
			};
			_dbcontext.users.Add(entity);
			_dbcontext.SaveChanges();
			return entity;
		}
		public void DeleteUser(UserRB rb)
		{
			UsersEntity entity = _dbcontext.users.FirstOrDefault(u => u.UserName == rb.UserName && u.Email == rb.Email && u.PasswordHash == rb.PasswordHash);
			if (entity != null)
			{
				entity.IsDeleted = true;
				TrashEntity trash = new TrashEntity
				{
					UserId = entity.Id,
				};
				_dbcontext.users.Update(entity);
				_dbcontext.trash.Add(trash);
				_dbcontext.SaveChanges();
			}
			else
			{
				Console.WriteLine("Error at UsersDAO");
			}
		}

		public List<UsersEntity> ReadUsers()
		{
			List<UsersEntity> list = _dbcontext.users.ToList();
			return list;
		}
	}
}
