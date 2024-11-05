using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
	public class Car : Vehicle
	{
		public Car(double fuelQunatity, double fuelConsumption) 
			: base(fuelQunatity, fuelConsumption)
		{
		}

		public override double FuelConsumption => base.FuelConsumption + 0.9;
	}
}
