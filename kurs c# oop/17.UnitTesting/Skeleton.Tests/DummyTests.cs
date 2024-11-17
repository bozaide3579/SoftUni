using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
	[TestFixture]
	public class DummyTests
	{
		private int _health, _experience;

		[SetUp]
		public void SetUp()
		{
			this._health = Random.Shared.Next(10, 100);
			this._experience = Random.Shared.Next(10, 100);
		}

		[Test]
		public void DummyShouldBeInitializedCorrectly()
		{
			Dummy dummy = new Dummy(_health, 0);

			Assert.That(dummy.Health, Is.EqualTo(_health));
			Assert.That(dummy.IsDead, Is.False);
		}

		[TestCase(0)]
		[TestCase(1)]
		public void DummyShouldBeDeadIfAttackedWithEnoughPower(int attackAdditive)
		{
			Dummy dummy = new Dummy(this._health, this._experience);

			dummy.TakeAttack(this._health + attackAdditive);

			Assert.That(dummy.Health, Is.EqualTo(-1 * attackAdditive));
			Assert.That(dummy.IsDead(), Is.True);
		}

		[Test]
		public void DeadDummyShouldNotBeAbleToAttack()
		{
			Dummy dummy = new Dummy(-1 * this._health, this._experience);

			Assert.Throws<InvalidOperationException>(
				 () => dummy.TakeAttack(1)
			);
		}

		[Test]
		public void AliveDummyShouldNotBeAbleToGiveXP()
		{
			Dummy dummy = new Dummy(this._health, this._experience);


			Assert.Throws<InvalidOperationException>(
				 () => dummy.GiveExperience()
			);
		}

		[Test]
		public void DeadDummyShouldBeAbleToGiveXP()
		{
			Dummy dummy = new Dummy(-1 * this._health, this._experience);

			int result = dummy.GiveExperience();

			Assert.That(result, Is.EqualTo(this._experience));
		}
	}
}