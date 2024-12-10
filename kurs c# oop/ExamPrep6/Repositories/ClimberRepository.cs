using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
	public class ClimberRepository : IRepository<IClimber>
	{
		private readonly List<IClimber> _all = new List<IClimber>();
		public IReadOnlyCollection<IClimber> All => _all;

		public void Add(IClimber model)
		{
			_all.Add(model);
		}

		public IClimber Get(string name)
		{
			return _all.FirstOrDefault(a => a.Name == name);
		}
	}
}
