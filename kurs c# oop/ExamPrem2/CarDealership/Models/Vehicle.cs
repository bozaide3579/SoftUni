﻿using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
	public abstract class Vehicle : IVehicle
	{
		private readonly List<string> _buyers;

		protected Vehicle(string model, double price)
		{
			if (string.IsNullOrWhiteSpace(model))
			{
				throw new ArgumentException(ExceptionMessages.ModelIsRequired);
			}

			if (price <= 0)
			{
				throw new ArgumentException(ExceptionMessages.PriceMustBePositive);
			}

			this.Model = model;
			this.Price = price;

			this._buyers = new List<string>();
			this.Buyers = this._buyers.AsReadOnly();
		}

		public string Model { get; }
		public double Price { get; }
		public IReadOnlyCollection<string> Buyers { get; }
		public int SalesCount => Buyers.Count;
		

		public void SellVehicle(string buyerName)
		{
			_buyers.Add(buyerName);
		}

		public override string ToString()
		{
			return $"{Model} - Price: {Price:F2}, Total Model Sales: {SalesCount}";
		}

	}
}
