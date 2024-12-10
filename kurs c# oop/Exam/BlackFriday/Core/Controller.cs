using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Core
{
	public class Controller : IController
	{
		private readonly Application _application = new Application();

		public string AddProduct(string productType, string productName, string userName, double basePrice)
		{
			IProduct product;
			if (productType == nameof(Item))
			{
				product = new Item(productName, basePrice);
			}
			else if (productType == nameof(Service))
			{
				product = new Service(productName, basePrice);
			}
			else
			{
				return string.Format(OutputMessages.ProductIsNotPresented, productType);
			}

			if (_application.Products.Exists(productName))
			{
				return string.Format(OutputMessages.ProductNameDuplicated, productName);
			}

			IUser user = _application.Users.GetByName(userName);
			if (user == null || !user.HasDataAccess)
			{
				return string.Format(OutputMessages.UserIsNotAdmin, userName);
			}

			_application.Products.AddNew(product);
			return string.Format(OutputMessages.ProductAdded, productType, productName, basePrice);

		}

		public string ApplicationReport()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Application administration:");

			List<IUser> admins = _application.Users.Models
				.Where(u => u.HasDataAccess)
				.OrderBy(u => u.UserName)
				.ToList();

			foreach (IUser admin in admins)
			{
				sb.AppendLine(admin.ToString());
			}

			List<IUser> clients = _application.Users.Models
				.Where(u => !u.HasDataAccess)
				.OrderBy(u => u.UserName)
				.ToList();

			sb.AppendLine("Clients:");
			foreach (Client client in clients)
			{
				sb.AppendLine(client.ToString());

				List<string> blackFridayPurchases = new List<string>();

				foreach (var productName in client.Purchases.Keys)
				{
					if (client.Purchases[productName])
					{
						blackFridayPurchases.Add(productName);
					}
				}

				if (blackFridayPurchases.Any())
				{
					sb.AppendLine($"-Black Friday Purchases: {blackFridayPurchases.Count}");
					foreach (string productName in blackFridayPurchases)
					{
						sb.AppendLine($"--{productName}");
					}
				}
			}

			return sb.ToString().Trim();
		}

		public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
		{
			IUser user = _application.Users.GetByName(userName);
			if (user == null || user.HasDataAccess)
			{
				return string.Format(OutputMessages.UserIsNotClient, userName);
			}

			IProduct product = _application.Products.GetByName(productName);
			if (product == null)
			{
				return string.Format(OutputMessages.ProductDoesNotExist, productName);
			}

			if (product.IsSold)
			{
				return string.Format(OutputMessages.ProductOutOfStock, productName);
			}

			double priceToPay = blackFridayFlag ? product.BlackFridayPrice : product.BasePrice;

			Client client = (Client)user;
			client.PurchaseProduct(productName, blackFridayFlag);

			product.ToggleStatus();
			return string.Format(OutputMessages.ProductPurchased, userName, productName, priceToPay);

		}

		public string RefreshSalesList(string userName)
		{
			IUser user = _application.Users.GetByName(userName);
			if (user == null || !user.HasDataAccess)
			{
				return string.Format(OutputMessages.UserIsNotAdmin, userName);
			}

			int updatedProductsCount = 0;
			foreach (IProduct product in _application.Products.Models)
			{
				if (product.IsSold)
				{
					product.ToggleStatus();
					updatedProductsCount++;
				}

			}

			return string.Format(OutputMessages.SalesListRefreshed, updatedProductsCount);
		}

		public string RegisterUser(string userName, string email, bool hasDataAccess)
		{
			if (_application.Users.Exists(userName))
			{
				return string.Format(OutputMessages.UserAlreadyRegistered, userName);
			}

			if (_application.Users.Models.Any(u => u.Email == email))
			{
				return string.Format(OutputMessages.SameEmailIsRegistered, email);
			}

			if (hasDataAccess)
			{
				if (_application.Users.Models.OfType<Admin>().Count() >= 2)
				{
					return string.Format(OutputMessages.AdminCountLimited);
				}

				IUser admin = new Admin(userName, email);
				_application.Users.AddNew(admin);
				return string.Format(OutputMessages.AdminRegistered, userName);
			}

			IUser client = new Client(userName, email);
			_application.Users.AddNew(client);
			return string.Format(OutputMessages.ClientRegistered, userName);
		}

		public string UpdateProductPrice(string productName, string userName, double newPriceValue)
		{
			IProduct product = _application.Products.GetByName(productName);
			if (product == null)
			{
				return string.Format(OutputMessages.ProductDoesNotExist, productName);
			}

			IUser user = _application.Users.GetByName(userName);
			if (user == null || !user.HasDataAccess)
			{
				return string.Format(OutputMessages.UserIsNotAdmin, userName);
			}

			double oldPrice = product.BasePrice;
			product.UpdatePrice(newPriceValue);
			return string.Format(OutputMessages.ProductPriceUpdated, productName, oldPrice, newPriceValue);
		}
	}
}
