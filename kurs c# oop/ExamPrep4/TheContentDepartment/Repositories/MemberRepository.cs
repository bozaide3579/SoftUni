using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
	public class MemberRepository : IRepository<ITeamMember>
	{
		private readonly List<ITeamMember> _members = new List<ITeamMember>();

		public IReadOnlyCollection<ITeamMember> Models => _members.AsReadOnly();

		public void Add(ITeamMember model)
		{
			_members.Add(model);
		}

		public ITeamMember TakeOne(string modelName)
		{
			return Models.FirstOrDefault(m => m.Name == modelName);
		}
	}
}
