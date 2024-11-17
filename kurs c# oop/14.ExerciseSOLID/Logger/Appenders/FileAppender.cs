using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
	public class FileAppender : BaseAppender
	{
		private readonly string _pathToFile;
		public FileAppender(string pathToFile, ILayout layout, Func<string, ReportLevel, string, bool>? filter = null) : base(layout, filter)
		{
			if (string.IsNullOrWhiteSpace(pathToFile))
				throw new ArgumentNullException(nameof(pathToFile));

			this._pathToFile = pathToFile;
		}

		protected override void Append(string formattedLogMessage)
		=>File.AppendAllLines(this._pathToFile, new string[1]  { formattedLogMessage });
	}
}
