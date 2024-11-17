using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
	public abstract class BaseAppender : IAppender
	{
		private readonly ILayout _layout;
		private readonly Func<string, ReportLevel, string, bool>? _filter;

		protected BaseAppender(ILayout layout, Func<string, ReportLevel, string, bool>? filter = null)
		{
			this._layout = layout ?? throw new ArgumentNullException(nameof(layout));
			_filter = filter;
		}

		public bool Append(string dateAndTime, ReportLevel reportlevel, string message)
		{
			if(this._filter != null && !this._filter(dateAndTime, reportlevel, message))
			{
				return false;
			}

			string formattedLogMessage = this._layout.Format(dateAndTime, reportlevel, message);
			this.Append(formattedLogMessage);

			return true;
		}

		protected abstract void Append(string formattedLogMessage);
	}
}
