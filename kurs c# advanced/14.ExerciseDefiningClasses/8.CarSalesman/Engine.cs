using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CarSalesman
{
	public class Engine
	{
		public Engine(string model, int power, int? displacement = null, string? efficiency = null)
		{
			this.Model = model;
			this.Power = power;
			this.Displacement = displacement;
			this.Efficiency = efficiency;
		}
		public string Model { get; }
		public int Power { get; }
		public int? Displacement { get; }
		public string? Efficiency { get; }

		public override string ToString()
		{
			StringBuilder resultBuilder = new StringBuilder();
			resultBuilder.AppendLine($"  {this.Model}:");
			resultBuilder.AppendLine($"    Power: {this.Power}");
			resultBuilder.AppendLine($"    Displacement: {this.Displacement?.ToString() ?? "n/a"}");
			resultBuilder.Append($"    Efficiency: {this.Efficiency ?? "n/a"}");

			return resultBuilder.ToString();
		}
	}
}
