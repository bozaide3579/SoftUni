using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
	public abstract class Product : IProduct
	{
		public string ProductName { get; private set; }
		public double BasePrice { get; private set; }
		public virtual double BlackFridayPrice => BasePrice;
		public bool IsSold { get; private set; } = false;

		protected Product(string productName, double basePrice)
		{
			if (string.IsNullOrWhiteSpace(productName))
			{
				throw new ArgumentException(ExceptionMessages.ProductNameRequired);
			}

			if (basePrice <= 0)
			{
				throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
			}

			ProductName = productName;
			BasePrice = basePrice;
		}

		public void ToggleStatus()
		{
			if (IsSold == true)
			{
				IsSold = false;
			}
			else
			{
				IsSold = true;
			}
		}

		public void UpdatePrice(double newPriceValue)
		{
			BasePrice = newPriceValue;
		}

		public override string ToString()
		{
			return $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice - BlackFridayPrice):F2}";
		}
	}
}
