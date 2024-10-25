using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
	public class Vehicle
	{
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; }
		public double Fuel { get; private set; }
        public virtual double FuelConsumption { get; } = 1.25;

        public void Drive(double kilometers)
        {
            double necessaryFuel = this.FuelConsumption * kilometers;
            this.Fuel -= necessaryFuel;
        }
	}
}
