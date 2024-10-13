using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
	public class Engine
	{
		private int horsePower;
		public double CubicCapacity;

		public Engine(int horsePower, double cubicCapacity)
		{
			HorsePower = horsePower;
			CubicCapacity = cubicCapacity;
		}

		public int HorsePower
		{
			get { return horsePower; }
			set { horsePower = value; }
		}

		private double cubicCapacity
		{
			get { return cubicCapacity; }
			set { cubicCapacity = value; }
		}

	}
}
