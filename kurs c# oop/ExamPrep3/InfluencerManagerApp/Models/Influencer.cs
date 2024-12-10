using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
	public abstract class Influencer : IInfluencer
	{
		private readonly List<string> _participations;
		private double _income;
		protected Influencer(string username, int followers, double engagementRate)
		{
			if (string.IsNullOrWhiteSpace(username))
			{
				throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
			}

			if (followers < 0)
			{
				throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
			}

			Username = username;
			Followers = followers;
			EngagementRate = engagementRate;

			_participations = new List<string>();
			Participations = _participations.AsReadOnly();
		}

		public string Username { get; }
		public int Followers { get; }
		public double EngagementRate { get; private set; }
		public double Income { get; private set; }
		
		public IReadOnlyCollection<string> Participations { get; }

		public virtual int CalculateCampaignPrice()
		{
			return (int)(Followers * EngagementRate);
		}

		public void EarnFee(double amount)
		{
			Income += amount;
		}

		public void EndParticipation(string brand)
		{
			_participations.Remove(brand);
		}

		public void EnrollCampaign(string brand)
		{
			_participations.Add(brand);
		}

		public override string ToString()
		{
			return $"{Username} - Followers: {Followers}, Total Income: {Income}";
		}
	}
}
