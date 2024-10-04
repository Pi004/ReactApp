using ReactApp1.Server.DBModels.Context;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace ReactApp1.Server.Helper
{
	public interface IHelper
	{
		public IQueryable<T> Search<T>(IQueryable<T> query, object frb);
	}
	public class Helper : IHelper
	{
		private readonly new ApplicationDBFactory _DbContext;
		public Helper(ApplicationDBFactory dbContext)
		{
			_DbContext = dbContext;
		}
		public IQueryable<T> Search<T>(IQueryable<T> query, object rb)
		{
			PropertyInfo[] properties = rb.GetType().GetProperties();
			List<string> columns = new List<string>();
			foreach (PropertyInfo property in properties)
			{
				object? value = property.GetValue(rb);
				if (value == null)
				{
					continue;
				}
				if (value.GetType() == typeof(string) || value.GetType() == typeof(int))
				{
					query = query.Where($"{property.Name} == @0", value);
				}
			}
			return query;
		}
	}
}
