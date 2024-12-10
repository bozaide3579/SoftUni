using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Core
{
	public class Controller : IController
	{
		private readonly IDealership dealership = new Dealership();

		public string AddCustomer(string customerTypeName, string customerName)
		{
			ICustomer customer;
			if (customerTypeName == "IndividualClient")
				customer = new IndividualClient(customerName);
			else if (customerTypeName == "LegalEntityCustomer")
				customer = new LegalEntityCustomer(customerName);
			else
				return string.Format(OutputMessages.InvalidType, customerTypeName);

			if (this.dealership.Customers.Exists(customerName))
				return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);

			dealership.Customers.Add(customer);
			return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
		}

		public string AddVehicle(string vehicleTypeName, string model, double price)
		{
			IVehicle vehicle;
			if (vehicleTypeName == nameof(SaloonCar))
				vehicle = new SaloonCar(model, price);
			else if (vehicleTypeName == nameof(SUV))
				vehicle = new SUV(model, price);
			else if (vehicleTypeName == nameof(Truck))
				vehicle = new Truck(model, price);
			else
				return string.Format(OutputMessages.InvalidType, vehicleTypeName);

			if (dealership.Vehicles.Exists(model))
				return string.Format(OutputMessages.VehicleAlreadyAdded, model);

			dealership.Vehicles.Add(vehicle);
			return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, vehicle.Price);
		}

		public string CustomerReport()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("Customer Report:");

			foreach (ICustomer customer in dealership.Customers.Models.OrderBy(c => c.Name))
			{
				sb.AppendLine();
				sb.AppendLine(customer.ToString());
				sb.Append("-Models:");

				if (customer.Purchases.Count == 0)
				{
					sb.AppendLine();
					sb.Append("--none");
				}
				else
				{
					foreach (string model in customer.Purchases.OrderBy(p => p))
					{
						sb.AppendLine();
						sb.Append($"--{model}");
					}
				}
			}
			return sb.ToString().Trim();
		}

		public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
		{
			ICustomer customer = dealership.Customers.Get(customerName);
			if (customer is null)
				return string.Format(OutputMessages.CustomerNotFound, customerName);

			IVehicle[] candidateVehicles = dealership.Vehicles.Models
				.Where(v => v.GetType().Name == vehicleTypeName)
				.ToArray();

			if (candidateVehicles.Length == 0)
				return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);

			if (!CanBuy(customer, vehicleTypeName))
				return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);


			IVehicle? vehicleToBuy = candidateVehicles
				.Where(v => v.Price <= budget)
				.OrderByDescending(v => v.Price)
				.FirstOrDefault();
			if (vehicleToBuy is null)
				return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);

			customer.BuyVehicle(vehicleToBuy.Model);
			vehicleToBuy.SellVehicle(customer.Name);
			return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customer.Name, vehicleToBuy.Model);

		}

		public string SalesReport(string vehicleTypeName)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{vehicleTypeName} Sales Report:");

			int totalSales = 0;
			foreach (IVehicle vehicle in dealership.Vehicles.Models
				.Where(v => v.GetType().Name == vehicleTypeName)
				.OrderBy(v => v.Model))
			{
				sb.AppendLine($"--{vehicle}");
				totalSales += vehicle.SalesCount;
			}

			sb.Append($"-Total Purchases: {totalSales}");

			return sb.ToString();


		}

		private bool CanBuy(ICustomer customer, string vehicleTypeName)
		{
			if (customer is IndividualClient)
				return vehicleTypeName == nameof(SaloonCar) || vehicleTypeName == nameof(SUV);
			if (customer is LegalEntityCustomer)
				return vehicleTypeName == nameof(SUV) || vehicleTypeName == nameof(Truck);

			return false;
		}
	}
}
