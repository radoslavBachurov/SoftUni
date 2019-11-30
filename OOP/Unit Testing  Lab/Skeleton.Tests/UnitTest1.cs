using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
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
            Assert.AreNotEqual(beforedurability, afterdurability ,"Axe Durability doesnt change after attack");
        }

        [Test]
        public void AtackMethodIsValidIfAtackWithBrokenMethodNotPossible()
        {
            try
            {
                for (int i = 0; i < 11; i++)
                {
                   testHero.Attack(new Dummy(3, 5));
                }
            }
            catch (Exception)
            {
                Assert.Pass();
            }

            Assert.Fail("You can still atack with broken weapon");
        }
    }
}