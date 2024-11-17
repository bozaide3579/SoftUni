using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Logger.Appenders
{
	public class ConsoleAppender : BaseAppender
	{
		public ConsoleAppender(ILayout layout, Func<string, ReportLevel, string, bool>? filter = null) 
			: base(layout, filter) 
		{
	
		}

		protected override void Append(string formattedLogMessage)
		=> Console.WriteLine(formattedLogMessage);
	}
}
