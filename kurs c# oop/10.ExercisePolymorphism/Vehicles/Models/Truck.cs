using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
	public class Truck : Vehicle
	{
		public Truck(double fuelQunatity, double fuelConsumption) 
			: base(fuelQunatity, fuelConsumption)
		{
		}

		public override double FuelConsumption => base.FuelConsumption + 1.6;

		public override void Refuel(double amount)
		{
			base.Refuel(amount * 0.95);
		}

	}
}
