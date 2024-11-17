using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
	public interface ILogger
	{
		void Log (string dateAndTime, ReportLevel reportLevel, string message);

		void Info(string dateAndTime, string message)
			=> this.Log(dateAndTime, ReportLevel.Info, message);

		void Warning(string dateAndTime, string message)
			=> this.Log(dateAndTime, ReportLevel.Warning, message);

		void Error(string dateAndTime, string message)
			=> this.Log(dateAndTime, ReportLevel.Error, message);

		void Critical(string dateAndTime, string message)
			=> this.Log(dateAndTime, ReportLevel.Critical, message);

		void Fatal(string dateAndTime, string message)
			=> this.Log(dateAndTime, ReportLevel.Fatal, message);
	}
}
