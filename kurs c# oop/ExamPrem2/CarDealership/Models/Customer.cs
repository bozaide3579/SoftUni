using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
	public abstract class Customer : ICustomer
	{
		private readonly List<string> _purchases;
		protected Customer(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(ExceptionMessages.NameIsRequired);
			}

			Name = name;
			_purchases = new List<string>();
			Purchases = _purchases.AsReadOnly();
		}
		public string Name { get; }
		public IReadOnlyCollection<string> Purchases { get; }

		public void BuyVehicle(string vehicleModel)
		{
			_purchases.Add(vehicleModel);
		}

		public override string ToString()
		{
			return $"{Name} - Purchases: {Purchases.Count}";
		}
	}
}
