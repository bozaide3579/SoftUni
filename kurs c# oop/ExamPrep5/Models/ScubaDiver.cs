﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
	public class ScubaDiver : Diver
	{
		public ScubaDiver(string name) 
			: base(name, 540)
		{
		}

		public override void Miss(int TimeToCatch)
		{
			int oxygenReduction = (int)Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);
			OxygenLevel = oxygenReduction;
		}

		public override void RenewOxy()
		{
			OxygenLevel = 540;
		}
	}
}
