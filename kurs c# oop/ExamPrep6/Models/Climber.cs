using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
	public abstract class Climber : IClimber
	{
		private readonly List<string> _conqueredPeaks = new List<string>();
		private int _stamina;

		protected Climber(string name, int stamina)
		{
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);

			Name = name;
			Stamina = stamina;

			ConqueredPeaks = _conqueredPeaks.AsReadOnly();
		}

		public string Name { get; private set; }
		public int Stamina
		{
			get => _stamina;
			protected set => _stamina = Math.Clamp(value, 0, 10);
			
		}
		public IReadOnlyCollection<string> ConqueredPeaks { get; }

		public void Climb(IPeak peak)
		{
			if (!_conqueredPeaks.Contains(peak.Name))
			{
				_conqueredPeaks.Add(peak.Name);
			}

			int staminaReduction = 0;
			if (peak.DifficultyLevel == "Extreme")
			{
				staminaReduction = 6;
			}
			else if (peak.DifficultyLevel == "Hard")
			{
				staminaReduction = 4;
			}
			else if (peak.DifficultyLevel == "Moderate")
			{
				staminaReduction = 2;
			}

			Stamina -= staminaReduction;
		}

		public abstract void Rest(int daysCount);

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			string climberTypeName = GetType().Name;
			sb.AppendLine($"{climberTypeName} - Name: {Name}, Stamina: {Stamina}");

			if (_conqueredPeaks.Count == 0)
			{
				sb.AppendLine("Peaks conquered: no peaks conquered");
			}
			else
			{
				sb.AppendLine($"Peaks conquered: {_conqueredPeaks.Count}");
			}

			return sb.ToString().Trim();
			
		}
	}
}
