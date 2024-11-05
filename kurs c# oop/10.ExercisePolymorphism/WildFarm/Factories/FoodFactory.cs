﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
	public class FoodFactory : IFoodsFactory
	{
		public IFood CreateFood(string type, int quantity)
		{
			switch (type)
			{
				case "Fruit": return new Fruit(quantity);
				case "Meat": return new Meat(quantity);
				case "Seeds": return new Seeds(quantity);
				case "Vegetable": return new Vegetable(quantity);
				default: throw new ArgumentNullException("Invalid food type");
			}
		}
	}
}
