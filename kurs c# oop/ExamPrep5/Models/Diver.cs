using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
	public abstract class Diver : IDiver
	{
		private readonly List<string> _catch = new List<string>();
		private int _oxygenLevel;
		private double _competitionPoints;

		protected Diver(string name, int oxygenLevel)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException(ExceptionMessages.DiversNameNull);

			Name = name;
			OxygenLevel = oxygenLevel;
			Catch = _catch.AsReadOnly();
		}

		public string Name { get; private set; }
		public int OxygenLevel
		{
			get => _oxygenLevel;
			protected set => _oxygenLevel = Math.Max(0, value);
		}
		public IReadOnlyCollection<string> Catch { get; }
		public double CompetitionPoints
		{
			get => Math.Round(_competitionPoints, 1, MidpointRounding.AwayFromZero);
			private set => _competitionPoints = value;
		}
		public bool HasHealthIssues { get; private set; } = false;

		public void Hit(IFish fish)
		{
			OxygenLevel -= fish.TimeToCatch;
			_catch.Add(fish.Name);
			CompetitionPoints += fish.Points;
		}

		public abstract void Miss(int TimeToCatch);

		public abstract void RenewOxy();

		public void UpdateHealthStatus()
		{
			HasHealthIssues = !HasHealthIssues;
		}

		public override string ToString()
		{
			return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {_catch.Count}, Points earned: {CompetitionPoints} ]";
		}
	}
}
