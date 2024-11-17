using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
	public class CommandInterpreter : Contracts.ICommandInterpreter
	{
		public string Read(string args)
		{
			string[] data = args.Split(' ', StringSplitOptions.RemoveEmptyEntries );

			Assembly assembly = Assembly.GetCallingAssembly();

			//ICommand command = new ExitCommand();
			string expectedCommandTypeName = $"{data[0]}Command";
			Type[] commandTypes = assembly.GetTypes()
				.Where(t => t.Name == expectedCommandTypeName && t.IsAssignableTo(typeof(ICommand)))
				.ToArray();

			if (commandTypes.Length == 0) return "Error: No matching command.";
			else if (commandTypes.Length > 1) return "Error: Multiple matching command.";
			else
			{
				ICommand command = (ICommand) Activator.CreateInstance(commandTypes[0]);
				return command.Execute(data.Skip(1).ToArray());
			}
		}
	}
}
 