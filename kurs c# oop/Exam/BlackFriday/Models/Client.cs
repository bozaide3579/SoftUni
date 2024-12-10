using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
	public class Client : User
	{
		private readonly Dictionary<string, bool> _purchases = new Dictionary<string, bool>();
		public Client(string userName, string email) 
			: base(userName, email, false)
		{
			Purchases = _purchases;
		}

		public IReadOnlyDictionary<string, bool> Purchases { get; }

		public void PurchaseProduct(string productName, bool blackFridayFlag)
		{
			if (!_purchases.ContainsKey(productName))
			{
				_purchases.Add(productName, blackFridayFlag);	
			}
			else
			{
				_purchases[productName] = blackFridayFlag;
			}
		}
	}
}
