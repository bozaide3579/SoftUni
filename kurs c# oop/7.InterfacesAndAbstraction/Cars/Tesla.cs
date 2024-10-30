using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
	internal class Tesla : BaseCar, ICar, IElectricCar
	{
		public int Battery { get; }
		public Tesla(string model, string color, int battery)
			: base(model, color)
		{
			this.Battery = battery;
		}

		protected override string Describe() => $"{base.Describe()} with {this.Battery} Batteries";


	}
}
