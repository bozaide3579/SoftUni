using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
	public class ContentMember : TeamMember
	{
		private static readonly HashSet<string> AllowedPaths = new() { "CSharp", "JavaScript", "Python", "Java" };
		public ContentMember(string name, string path) 
			: base(name, path)
		{
			if (!AllowedPaths.Contains(path))
			{
				throw new ArgumentException(ExceptionMessages.PathIncorrect, Path);
			}

			Path = path;
		}

		public override string ToString()
		{
			return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
		}
	}
}
