using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
	public class Hen : Bird
	{
		public Hen(string name, double weight, double wingSize) 
			: base(name, weight, wingSize)
		{
		}

		public override double WeightMultiplier => 0.35;

		public override string ProduceSound()
		{
			return "Cluck";
		}
	}
}
