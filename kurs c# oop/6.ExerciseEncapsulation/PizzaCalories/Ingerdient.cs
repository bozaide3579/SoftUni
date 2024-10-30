using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
	public class Ingerdient
	{
		public Ingerdient(double weightInGrams)
		{
			this.WeightInGrams = weightInGrams;
		}

		public double WeightInGrams { get; }

		public virtual double Calories => 2 * WeightInGrams;
	}
}
