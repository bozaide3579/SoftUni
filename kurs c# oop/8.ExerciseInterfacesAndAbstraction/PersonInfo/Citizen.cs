using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
	public class Citizen : IBirthable, IIdentifiable, IPerson
	{
		public Citizen(string name, int age, string id, string birthdate)
		{
			this.Name = name;
			this.Age = age;
			this.Id = id;
			this.Birthdate = birthdate;
		}

		public string Name { get; }

		public int Age { get; }

		public string Birthdate {  get; }

		public string Id { get; }
	}
}
