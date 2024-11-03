using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
	public class LieutenantGeneral : Private, ILieutenantGeneral
	{
		private readonly List<ISoldier> _privates;
		public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IEnumerable<ISoldier> privates) 
			: base(id, firstName, lastName, salary)
		{
			this._privates = new List<ISoldier>(privates);
			this.Privates = this._privates.AsReadOnly();
		}

		public IReadOnlyCollection<ISoldier> Privates {  get; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(base.ToString());
			sb.Append("Privates:");
			foreach (ISoldier soldier in this.Privates)
			{
				sb.AppendLine();
				sb.Append($"  {soldier}");
			}

			return sb.ToString();
		}
	}
}
