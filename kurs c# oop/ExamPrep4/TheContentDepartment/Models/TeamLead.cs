using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
	public class TeamLead : TeamMember
	{
		public TeamLead(string name, string path) 
			: base(name, path)
		{
			if (path != "Master")
			{
				throw new ArgumentException(ExceptionMessages.PathIncorrect, path);
			}
			Path = path;	
		}

		public override string ToString()
		{
			string objectTypeName = GetType().Name;

			return $"{Name} ({objectTypeName}) – Currently working on {InProgress.Count} tasks.";
		}
	}
}
