using System;
using System.Text;
using System.Linq;

namespace SoftUniKindergarten
{
	public class Kindergarten
	{
		public string Name { get; }
		public int Capacity { get; }
		public List<Child> Registry { get; }

        public Kindergarten(string name, int capacity)
        {
            Name = name;
			Capacity = capacity;
			Registry = new List<Child>();
        }

		public bool AddChild(Child child)
		{
			if (Registry.Count < Capacity)
			{
				Registry.Add(child);
				return true;
			}

			return false;
		}

		public bool RemoveChild(string childFullName)
		{
			var child = Registry.FirstOrDefault(c => $"{c.FirstName} {c.LastName}" == childFullName);
			if (child != null)
			{
				Registry.Remove(child);
				return true;
			}

			return false;
		}

		public int ChildrenCount => Registry.Count;

		public Child GetChild(string childFullName)
		{
			var child = Registry.FirstOrDefault(c => $"{c.FirstName} {c.LastName}" == childFullName);

			if (child != null)
			{
				return child;
			}

			return null;
		}

		public string RegistryReport()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Registered children in {Name}:");

			bool isFirst = true;
			foreach (var kid in Registry.OrderByDescending(c => c.Age)
				.ThenBy(c => c.LastName)
				.ThenBy(c => c.FirstName))
			{
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
					sb.AppendLine();
				}

				sb.Append($"{kid}");
			}

			return sb.ToString().Trim();
		}
	}
}
