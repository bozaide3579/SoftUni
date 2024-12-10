using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
	public class PeakRepository : IRepository<IPeak>
	{
		private List<IPeak> _all = new List<IPeak>();
		public IReadOnlyCollection<IPeak> All => _all;

		public void Add(IPeak model)
		{
			_all.Add(model);
		}

		public IPeak Get(string name)
		{
			return _all.FirstOrDefault(a => a.Name == name);
		}
	}
}
