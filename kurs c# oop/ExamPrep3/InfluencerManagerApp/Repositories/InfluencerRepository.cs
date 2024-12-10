using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InfluencerManagerApp.Repositories
{
	public class InfluencerRepository : IRepository<IInfluencer>
	{
		private readonly List<IInfluencer> _influencers = new List<IInfluencer>();

		public IReadOnlyCollection<IInfluencer> Models => _influencers.AsReadOnly();

		public void AddModel(IInfluencer model)
		{
			_influencers.Add(model);
		}

		public IInfluencer FindByName(string name)
		{
			return _influencers.FirstOrDefault(i => i.Username == name);
		}

		public bool RemoveModel(IInfluencer model)
		{
			return _influencers.Remove(model);
		}
	}
}
