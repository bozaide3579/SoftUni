﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Commands
{
	public class ExitCommand : ICommand
	{
		public string Execute(string[] args)
		{
			Environment.Exit(exitCode: 0);
			return string.Empty; 
		}
	}
}
