using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
	public class CampaignRepository : IRepository<ICampaign>
	{
		private readonly List<ICampaign> _campaigns = new List<ICampaign>();

		public IReadOnlyCollection<ICampaign> Models => _campaigns.AsReadOnly();

		public void AddModel(ICampaign model)
		{
			_campaigns.Add(model);
		}

		public ICampaign FindByName(string name)
		{
			return _campaigns.FirstOrDefault(c => c.Brand ==  name);
		}

		public bool RemoveModel(ICampaign model)
		{
			return _campaigns.Remove(model);
		}
	}
}
