using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Hero testHero;
        private Dummy testDummy;

        [SetUp]
        public void Setup()
        {
            testHero = new Hero("John");
            testDummy = new Dummy(10,10);
        }

        [Test]
        public void AtackMethodTakesDamageFromDummyIsValid()
        {
            var healthBefore = testDummy.Health;
            testHero.Attack(testDummy);
            Assert.AreNotEqual(healthBefore, testDummy.Health,"Damage from dummy not taken");
        }

        [Test]
        public void IfDeadDummyGetHitThrowsException()
        {
            for (int i = 0; i < 1; i++)
            {
                testHero.Attack(testDummy);
            }

            Assert.Throws<InvalidOperationException>(() => testHero.Attack(testDummy),"Doesnt throw exception when dummy dead");
        }

        [Test]
        public void ValidWhenDummyGiveExpirienceWhenKilled()
        {
            var startExpirience = testHero.Experience;

            testHero.Attack(testDummy);

            var endExpirience = testHero.Experience;

            Assert.AreNotEqual(startExpirience, endExpirience,"Dummy doesnt give exp when dies");
        }

        [Test]
        public void ValidWhenDummyDontGiveExpWhenAlive()
        {
            testDummy = new Dummy(20, 20);

            var startExpirience = testHero.Experience;

            testHero.Attack(testDummy);

            var endExpirience = testHero.Experience;

            Assert.AreEqual(startExpirience, endExpirience,"Dummy give exp when alive");
        }

    }
}
