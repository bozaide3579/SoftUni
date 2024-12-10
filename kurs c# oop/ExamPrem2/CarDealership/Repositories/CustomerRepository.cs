using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
	public class CustomerRepository : IRepository<ICustomer>
	{
		private readonly Dictionary<string, ICustomer> _customers = new Dictionary<string, ICustomer>();

		public IReadOnlyCollection<ICustomer> Models => _customers.Values;

		public void Add(ICustomer customer)
		{
			_customers[customer.Name] = customer;
		}

		public bool Exists(string text)
		{
			return _customers.ContainsKey(text);
		}

		public ICustomer Get(string text)
		{
			if (!Exists(text)) return null;
			return _customers[text];
		}

		public bool Remove(string text)
		{
			return _customers.Remove(text);
		}


	}
}
