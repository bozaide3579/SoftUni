﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
	public interface ILieutenantGeneral : IPrivate
	{
		IReadOnlyCollection<ISoldier> Privates { get; }
	}
}
