using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
	public interface ILayout
	{
		string Format(string dateAndTime, ReportLevel reportlevel, string message);
	}
}
