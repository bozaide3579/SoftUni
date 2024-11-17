using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
	public class Logger : ILogger
	{
		private readonly IAppender[] _appenders;

		public Logger(params IAppender[] appenders)
		{
			this._appenders = appenders;
		}

		public void Log(string dateAndTime, ReportLevel reportLevel, string message)
		{
			foreach (IAppender appender in this._appenders)
			{
				appender.Append(dateAndTime, reportLevel, message);
			}
		}
	}
}
