using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
	public abstract class Resource : IResource
	{
		protected Resource(string name, string creator, int priority)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);

			Name = name;
			Creator = creator;
			Priority = priority;
		}

		public string Name { get; private set; }
		public string Creator { get; }
		public int Priority { get; }
		public bool IsTested { get; private set; } = false;
		
		public bool IsApproved { get; private set; } =false;

		public void Approve()
		{
			IsApproved = true;
		}

		public void Test()
		{
			IsTested = true;	
		}

		public override string ToString()
		{
			string objectTypeName = GetType().Name;

			return $"{Name} ({objectTypeName}), Created By: {Creator}";
		}
	}
}
