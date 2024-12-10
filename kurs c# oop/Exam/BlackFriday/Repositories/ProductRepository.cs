using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
	public class ProductRepository : IRepository<IProduct>
	{
		private readonly List<IProduct> _models = new List<IProduct>();
		public IReadOnlyCollection<IProduct> Models => _models.AsReadOnly();

		public void AddNew(IProduct model)
		{
			_models.Add(model);
		}

		public bool Exists(string name)
		{
			return _models.Any(n => n.ProductName == name);
		}

		public IProduct GetByName(string name)
		{
			return _models.FirstOrDefault(n => n.ProductName == name);
		}
	}
}
