using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
	public class Private : BaseSoldier, IPrivate
	{
		public Private(int id, string firstName, string lastName, decimal salary) 
			: base(id, firstName, lastName)
		{
			this.Salary = salary;
		}

		public decimal Salary { get; }

		public override string ToString()
		{
			return $"{base.ToString()} Salary: {this.Salary:f2}";
		}
	}
}
