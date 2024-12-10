using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
	public class Controller : IController
	{
		private readonly DiverRepository _divers = new DiverRepository();
		private readonly FishRepository _fish = new FishRepository();

		public string ChaseFish(string diverName, string fishName, bool isLucky)
		{
			IDiver diver = _divers.GetModel(diverName);
			if (diver == null)
			{
				return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
			}

			IFish fish = _fish.GetModel(fishName);
			if (fish == null)
			{
				return string.Format(OutputMessages.FishNotAllowed, fishName);
			}

			if (diver.HasHealthIssues)
			{
				return string.Format(OutputMessages.DiverHealthCheck, diverName);
			}

			if (diver.OxygenLevel < fish.TimeToCatch)
			{
				diver.Miss(fish.TimeToCatch);
				if (diver.OxygenLevel <= 0)
				{
					diver.UpdateHealthStatus();
				}
				return string.Format(OutputMessages.DiverMisses, diverName, fishName);
			}

			if (diver.OxygenLevel == fish.TimeToCatch && isLucky == false)
			{
				diver.Miss(fish.TimeToCatch);
				if (diver.OxygenLevel <= 0)
				{
					diver.UpdateHealthStatus();
				}
				return string.Format(OutputMessages.DiverMisses, diverName, fishName);
			}

			if (diver.OxygenLevel == fish.TimeToCatch && isLucky == true)
			{
				diver.Hit(fish);
				if (diver.OxygenLevel <= 0)
				{
					diver.UpdateHealthStatus();
				}

				return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
			}

			if (diver.OxygenLevel > fish.TimeToCatch)
			{
				diver.Hit(fish);
				if (diver.OxygenLevel <= 0)
				{
					diver.UpdateHealthStatus();
				}

				return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
			}

			return null;
		}

		public string CompetitionStatistics()
		{
			StringBuilder sb = new StringBuilder();

			var healthyDivers = _divers.Models
	   .Where(d => !d.HasHealthIssues && d.OxygenLevel > 0)
	   .OrderByDescending(d => d.CompetitionPoints)
	   .ThenByDescending(d => d.Catch.Count)
	   .ThenBy(d => d.Name)
	   .ToList();

			sb.AppendLine("**Nautical-Catch-Challenge**");
			foreach (var diver in healthyDivers)
			{
				sb.AppendLine(diver.ToString());
			}

			return sb.ToString().Trim();
		}

		public string DiveIntoCompetition(string diverType, string diverName)
		{
			IDiver diver;

			if (diverType == nameof(FreeDiver))
			{
				diver = new FreeDiver(diverName);
			}
			else if (diverType == nameof(ScubaDiver))
			{
				diver = new ScubaDiver(diverName);
			}
			else
			{
				return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
			}

			if (_divers.Models.Any(d => d.Name == diverName))
			{
				return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
			}

			_divers.AddModel(diver);
			return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
		}

		public string DiverCatchReport(string diverName)
		{
			IDiver diver = _divers.GetModel(diverName);
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(diver.ToString());
			sb.AppendLine("Catch Report:");
			foreach (var fishName in diver.Catch)
			{
				var fish = _fish.GetModel(fishName);

				if (fish != null)
				{
					sb.AppendLine(fish.ToString());
				}
			}

			return sb.ToString().Trim();
		}

		public string HealthRecovery()
		{
			int count = 0;

			foreach (var diver in _divers.Models)
			{
				if (diver.HasHealthIssues || diver.OxygenLevel == 0)
				{
					count++;
					diver.UpdateHealthStatus();
					diver.RenewOxy();
				}
			}

			return string.Format(OutputMessages.DiversRecovered, count);
		}

		public string SwimIntoCompetition(string fishType, string fishName, double points)
		{
			IFish fish;

			if (fishType == nameof(ReefFish))
			{
				fish = new ReefFish(fishName, points);
			}
			else if (fishType == nameof(DeepSeaFish))
			{
				fish = new DeepSeaFish(fishName, points);
			}
			else if (fishType == nameof(PredatoryFish))
			{
				fish = new PredatoryFish(fishName, points);
			}
			else
			{
				return string.Format(OutputMessages.FishTypeNotPresented, fishType);
			}

			if (_fish.Models.Any(f => f.Name == fishName))
			{
				return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
			}

			_fish.AddModel(fish);
			return string.Format(OutputMessages.FishCreated, fishName);
		}
	}
}
