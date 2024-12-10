using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
	public abstract class TeamMember : ITeamMember
	{
		private readonly List<string> _inProgress = new List<string>();
		protected TeamMember(string name, string path)
		{
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);

			Name = name;
			Path = path;

			_inProgress = new List<string>();
			InProgress = _inProgress.AsReadOnly();
		}

		public string Name { get; }
		public string Path { get; protected set; }
		public IReadOnlyCollection<string> InProgress { get; }

		public void FinishTask(string resourceName)
		{
			_inProgress.Remove(resourceName);
		}

		public void WorkOnTask(string resourceName)
		{
			_inProgress.Add(resourceName);
		}

	}
}
