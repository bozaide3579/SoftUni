using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
	public abstract class Fish : IFish
	{
		protected Fish(string name, double points, int timeToCatch)
		{
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException(ExceptionMessages.FishNameNull);

			if (points < 1 && points > 10)
				throw new ArgumentException(ExceptionMessages.PointsNotInRange);

			Name = name;
			Points = points;
			TimeToCatch = timeToCatch;
		}

		public string Name { get; private set; }
		public double Points { get; private set; }
		public int TimeToCatch { get; }

		public override string ToString()
		{
			string typeName = GetType().Name;

			return $"{typeName}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
		}
	}
}
