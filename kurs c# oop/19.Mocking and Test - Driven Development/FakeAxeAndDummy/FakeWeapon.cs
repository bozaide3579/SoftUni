using FakeAxeAndDummy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAxeAndDummy
{
	public class FakeWeapon : IWeapon
	{
		public int AttackPoints => 10;

		public int DurabilityPoints => 10;

		public void Attack(ITarget target)
		{
			target.TakeAttack(AttackPoints);
		}
	}
}
