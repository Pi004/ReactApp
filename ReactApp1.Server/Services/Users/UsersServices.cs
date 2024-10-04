using ReactApp1.Server.DBModels.Users;
using ReactApp1.Server.DTO;
using ReactApp1.Server.RBModels.Users;

namespace ReactApp1.Server.Services.Users
{
	public interface IUserService
	{
		public ResponseDTO Create(UserRB rb);
		public ResponseDTO Delete(DelUserRB rb);
		public ResponseDTO Read();
	}
	public class UsersServices : IUserService
	{
		private readonly IUsers _users;
		public ResponseDTO response = new ResponseDTO { };
		public UsersServices(IUsers users)
		{
			_users = users;
		}

		public ResponseDTO Create(UserRB rb)
		{
			try
			{
				response.data = _users.CreateUser(rb);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return response;
			}
		}

		public ResponseDTO Delete(DelUserRB rb)
		{
			try
			{
				response.data = _users.DeleteUser(rb);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return response;
			}
		}

		public ResponseDTO Read()
		{
			try
			{
				SearchUsersRB srb = new SearchUsersRB { };
				response.data = _users.ReadUsers(srb);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return response;
			}
		}
	}
}
