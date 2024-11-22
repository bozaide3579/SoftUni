using FakeAxeAndDummy;
using FakeAxeAndDummy.Interfaces;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
	[Test]
	public void HeroGainsXPWhenTargetDies()
	{
		Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
		Mock<ITarget> mockTarget = new Mock<ITarget>();

		mockTarget.Setup(t => t.IsDead()).Returns(true);
		mockTarget.Setup(t => t.GiveExperience()).Returns(20);

		Hero hero = new Hero("Test Hero", mockWeapon.Object);

		hero.Attack(mockTarget.Object);

		Assert.AreEqual(20, hero.Experience);



		/*IWeapon weapon = new FakeWeapon();
		ITarget target = new FakeTarget();
		Hero hero = new Hero("Test Hero", weapon);

		hero.Attack(target);

		Assert.AreEqual(20, hero.Experience, "Hero did not gain correct Xp");*/
	}
}

