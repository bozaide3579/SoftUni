using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
	public class ResourceRepository : IRepository<IResource>
	{
		private List<IResource> _resources = new List<IResource>();

		public IReadOnlyCollection<IResource> Models => _resources.AsReadOnly();

		public void Add(IResource model)
		{
			_resources.Add(model);
		}

		public IResource TakeOne(string modelName)
		{
			return _resources.FirstOrDefault(r => r.Name == modelName);
		}
	}
}
