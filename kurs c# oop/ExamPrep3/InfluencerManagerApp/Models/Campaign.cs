using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
	public abstract class Campaign : ICampaign
	{
		private readonly List<string> _contributors;

		protected Campaign(string brand, double budget)
		{
			if (string.IsNullOrWhiteSpace(brand))
			{
				throw new ArgumentException(ExceptionMessages.BrandIsrequired);
			}

			Brand = brand;
			Budget = budget;

			_contributors = new List<string>();
			Contributors = _contributors.AsReadOnly();
		}

		public string Brand { get; }
		public double Budget { get; private set;  }
		public IReadOnlyCollection<string> Contributors { get; }

		public void Engage(IInfluencer influencer)
		{
			_contributors.Add(influencer.Username);
			Budget -= influencer.CalculateCampaignPrice();
		}

		public void Gain(double amount)
		{
			Budget += amount;
		}

		public override string ToString()
		{
			string campaignTypeName = this.GetType().Name;

			return $"{campaignTypeName} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
		}
	}
}
