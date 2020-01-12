using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Hero testHero;

        [SetUp]
        public void Setup()
        {
            testHero = new Hero("John");
        }

        [Test]
        public void AtackMethodIsValidIfWeaponLossesDurabilityAfterAtack()
        {
            var beforedurability = testHero.Weapon.DurabilityPoints;
            testHero.Attack(new Dummy(3, 5));
            var afterdurability = testHero.Weapon.DurabilityPoints;
            Assert.AreNotEqual(beforedurability, afterdurability, "Axe Durability doesnt change after attack");
        }

        [Test]
        public void AtackMethodIsValidIfAtackWithBrokenMethodNotPossible()
        {
            for (int i = 0; i < 10; i++)
            {
                testHero.Attack(new Dummy(3, 5));
            }

            Assert.Throws<InvalidOperationException>(() => testHero.Attack(new Dummy(3, 5)),"Atack with broken weapon possible");
        }
    }
}
