﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
	public class SmartPhone : ICaller, IBrowser
	{
		public string Browse(string url)
		{
			return $"Browsing: {url}!";
		}

		public string Call(string phoneNumber)
		{
			return $"Calling... {phoneNumber}";
		}
	}
}
