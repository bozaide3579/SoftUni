using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.EqualityLogic
{
	public class Person : IEquatable<Person>, IComparable<Person>
	{
		public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;
		}

		public string Name { get; }
		public int Age { get; }

		public int CompareTo(Person? other)
		{
			if (other == null) return 1;
			if (ReferenceEquals(this, other)) return 0;

			int nameCompareResults = string.Compare(this.Name, other.Name);
			if (nameCompareResults != 0) return nameCompareResults;

			return this.Age.CompareTo(other.Age);
		}

		public override bool Equals(object? obj)
		{
			if (obj is not Person p) return false;
			return this.Equals(p);
		}

		public bool Equals(Person? other) => this.CompareTo(other) == 0;
		

		public override int GetHashCode()
		=> HashCode.Combine(this.Name, this.Age);



	}
}
