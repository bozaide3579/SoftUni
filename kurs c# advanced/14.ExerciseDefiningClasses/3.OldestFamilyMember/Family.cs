using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
	public class Family
	{
		private readonly List<Person> _members = new List<Person>();

		public void AddMember(Person member)
			=> this._members.Add(member);
		
		public Person GetOldestMember()
			=> this._members.MaxBy(p => p.Age);

	}
}
