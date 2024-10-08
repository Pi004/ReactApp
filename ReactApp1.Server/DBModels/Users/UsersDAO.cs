using ReactApp1.Server.DBModels.Context;
using ReactApp1.Server.Helper;
using ReactApp1.Server.RBModels.Users;

namespace ReactApp1.Server.DBModels.Users
{
	public interface IUsers
	{
		public UsersEntity CreateUser(UserRB rb);
		public UsersEntity? DeleteUser(DelUserRB rb);
		public List<UsersEntity>? ReadUsers(SearchUsersRB srb);
	}
	public class UsersDAO : IUsers
	{
		public readonly new ApplicationDBFactory _dbcontext;
		public readonly IHelper _helper;
		public SearchUsersRB srb = new SearchUsersRB { };

		public UsersDAO(ApplicationDBFactory dbcontext, IHelper helper)
		{
			_dbcontext = dbcontext;
			_helper = helper;
		}

		public UsersEntity CreateUser(UserRB rb)
		{
			try
			{
				UsersEntity entity = new UsersEntity
				{
					Email = rb.Email,
					UserName = rb.UserName,
				};
				_helper.PasswordHash(entity, rb);
				_dbcontext.users.Add(entity);
				_dbcontext.SaveChanges();
				return entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		public UsersEntity? DeleteUser(DelUserRB rb)
		{
			try
			{
				IQueryable<UsersEntity> query = _dbcontext.users.AsQueryable();
				UsersEntity entity = _helper.Search(query, rb).ToList()[0];
				_dbcontext.users.Remove(entity);
				_dbcontext.SaveChanges();
				return entity;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}

		public List<UsersEntity>? ReadUsers(SearchUsersRB srb)
		{
			try
			{
				IQueryable<UsersEntity> query = _dbcontext.users.AsQueryable();
				return _helper.Search(query, srb).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}");
				return null;
			}
		}
	}
}
