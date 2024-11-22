using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAxeAndDummy.Interfaces
{
    public interface ITarget
    {

		int Health { get; }

		int GiveExperience();

		bool IsDead();

		void TakeAttack(int attackPoints);

	}
}
