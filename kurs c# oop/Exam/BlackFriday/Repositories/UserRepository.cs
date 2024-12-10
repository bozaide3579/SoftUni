using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
	public class UserRepository : IRepository<IUser>
	{
		private readonly List<IUser> _models = new List<IUser>();
		public IReadOnlyCollection<IUser> Models => _models.AsReadOnly();

		public void AddNew(IUser model)
		{
			_models.Add(model);
		}

		public bool Exists(string name)
		{
			return _models.Any(n => n.UserName == name);
		}

		public IUser GetByName(string name)
		{
			return _models.FirstOrDefault(n => n.UserName == name);
		}
	}
}
