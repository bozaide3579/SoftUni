using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
	public class Peak : IPeak
	{
		public Peak(string name, int elevation, string difficultyLevel)
		{
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);

			if (elevation <= 0)
				throw new ArgumentException(ExceptionMessages.PeakElevationNegative);

			Name = name;
			Elevation = elevation;
			DifficultyLevel = difficultyLevel;
		}

		public string Name { get; private set; }
		public int Elevation { get; private set; }
		public string DifficultyLevel { get; private set; }

		public override string ToString()
		{
			return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
		}
	}
}
