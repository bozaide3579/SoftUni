using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Core
{
	public class Controller : IController
	{
		private readonly PeakRepository _peakRepository = new PeakRepository();
		private readonly ClimberRepository _climberRepository = new ClimberRepository();
		private readonly BaseCamp _baseCamp = new BaseCamp();

		public string AddPeak(string name, int elevation, string difficultyLevel)
		{
			IPeak peak;

			if (_peakRepository.Get(name) is not null)
			{
				return string.Format(OutputMessages.PeakAlreadyAdded);
			}

			if (difficultyLevel == "Extreme")
			{
				peak = new Peak(name, elevation, difficultyLevel);
			}
			else if (difficultyLevel == "Hard")
			{
				peak = new Peak(name, elevation, difficultyLevel);
			}
			else if (difficultyLevel == "Moderate")
			{
				peak = new Peak(name, elevation, difficultyLevel);
			}
			else
			{
				return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
			}

			_peakRepository.Add(peak);
			return string.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));
		}

		public string AttackPeak(string climberName, string peakName)
		{
			IClimber climber = _climberRepository.Get(climberName);
			if (climber is null)
			{
				return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
			}

			IPeak peak = _peakRepository.Get(peakName);
			if (peak is null)
			{
				return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
			}

			if (!_baseCamp.Residents.Contains(climberName))
			{
				return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
			}

			if (peak.DifficultyLevel == "Extreme" && climber is NaturalClimber)
			{
				return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
			}

			climber.Climb(peak);
			_baseCamp.LeaveCamp(climber.Name);

			if (climber.Stamina == 0)
			{
				return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
			}

			_baseCamp.ArriveAtCamp(climber.Name);
			return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
		}

		public string BaseCampReport()
		{
			StringBuilder sb = new StringBuilder();


			if (_baseCamp.Residents is not null)
			{
				sb.AppendLine("BaseCamp residents:");
				foreach (var resident in _baseCamp.Residents)
				{
					var climber = _climberRepository.All.FirstOrDefault(x => x.Name == resident);

					sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
				}
			}
			else
			{
				sb.AppendLine("BaseCamp is currently empty.");
			}

			return sb.ToString().Trim();
		}

		public string CampRecovery(string climberName, int daysToRecover)
		{
			IClimber climber = _climberRepository.Get(climberName);

			if (!_baseCamp.Residents.Contains(climberName))
			{
				return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
			}

			if (climber.Stamina == 10)
			{
				return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
			}

			climber.Rest(daysToRecover);
			return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);

		}

		public string NewClimberAtCamp(string name, bool isOxygenUsed)
		{
			IClimber climber;

			if (_climberRepository.Get(name) is not null)
			{
				return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
			}

			if (isOxygenUsed == true)
			{
				climber = new OxygenClimber(name);
			}
			else
			{
				climber = new NaturalClimber(name);
			}

			_climberRepository.Add(climber);
			_baseCamp.ArriveAtCamp(climber.Name);
			return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
		}

		public string OverallStatistics()
		{
			StringBuilder sb = new StringBuilder();

			List<IClimber> orderedClimbers = _climberRepository.All
				.OrderByDescending(c => c.ConqueredPeaks.Count)
				.ThenBy(c => c.Name)
				.ToList();

			sb.AppendLine("***Highway-To-Peak***");

			foreach (IClimber climber in orderedClimbers)
			{
				sb.AppendLine(climber.ToString());

				List<IPeak> orderedPeaks = climber.ConqueredPeaks
					.Select(peakName => _peakRepository.Get(peakName))
					.OrderByDescending(peak => peak.Elevation)
					.ToList();

				foreach (IPeak peak in orderedPeaks)
				{
					sb.AppendLine(peak.ToString());
				}
			}

			return sb.ToString().Trim();
		}
	}
}
