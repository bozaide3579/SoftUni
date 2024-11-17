using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
	public class Engine : IEngine
	{
		private readonly Contracts.ICommandInterpreter _commandInterpreter;

		public Engine(Contracts.ICommandInterpreter commandInterpreter)
		{
			this._commandInterpreter = commandInterpreter ?? throw new ArgumentNullException(nameof(commandInterpreter));
		}

		public void Run()
		{
			while (true)
			{
				string input = Console.ReadLine();

				string output = this._commandInterpreter.Read(input);
				Console.WriteLine(output);
			}
		}
	}
}
