﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
	public class FreeDiver : Diver
	{
		public FreeDiver(string name) 
			: base(name, 120)
		{
		}

		public override void Miss(int TimeToCatch)
		{
			int oxygenReduction = (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
			OxygenLevel = oxygenReduction;
		}

		public override void RenewOxy()
		{
			OxygenLevel = 120;
		}
	}
}
