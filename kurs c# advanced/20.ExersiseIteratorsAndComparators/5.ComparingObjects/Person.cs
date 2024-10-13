using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ComparingObjects
{
	public class Person : IComparable<Person>
	{
		public Person(string name, int age, string town)
		{
			Name = name;
			Age = age;
			Town = town;
		}


		public string Name { get; }
		public int Age { get; }
		public string Town { get; }

		public int CompareTo(Person? other)
		{
			if (other is null)
			{
				return -1;
			}

			int nameResult = this.Name.CompareTo(other.Name);
			if (nameResult != 0)
			{
				return nameResult;
			}

			int ageResult = this.Age.CompareTo(other.Age);
			if (ageResult != 0)
			{
				return ageResult;
			}

			int townResult = this.Town.CompareTo(other.Town);
			if (townResult != 0)
			{
				return townResult;
			}

			return 0;
		}
	}
}
