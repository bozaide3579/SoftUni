using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Layouts
{
	public class XmlLayout : ILayout
	{
		public string Format(string dateAndTime, ReportLevel reportlevel, string message)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("<log>");
			sb.AppendLine($"   <date>{dateAndTime}</date>");
			sb.AppendLine($"   <level>{reportlevel}</level>");
			sb.AppendLine($"   <message>{message}</message>");
			sb.Append("</log>");

			return sb.ToString();
		}
	}
}
