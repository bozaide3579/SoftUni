using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
	public class Vehicle : IVehicle
	{
		protected Vehicle(double fuelQunatity, double fuelConsumption)
		{
			FuelQunatity = fuelQunatity;
			FuelConsumption = fuelConsumption;
		}

		public double FuelQunatity { get; private set; }

		public virtual double FuelConsumption { get; private set; }

		public bool Drive(double distance)
		{
			if (FuelQunatity < distance * FuelConsumption)
			{
				return false;
			}

			FuelQunatity -= distance * FuelConsumption;

			return true;
		}

		public virtual void Refuel(double amount)
		{
			FuelQunatity += amount;
		}

		public override string ToString()
		{
			return $"{this.GetType().Name}: {FuelQunatity:f2}";
		}
	}
}
