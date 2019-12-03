using NUnit.Framework;
//using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Name cannot be null or white space")]
        public void ValidIfThrowExceptionIfNameIsNullOrWhiteSpace(string message)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 30, 20), message);
            Assert.Throws<ArgumentException>(() => new Warrior(null, 30, 20), message);
        }

        [TestCase("Damage cannot be zero or negative")]
        public void ValidIfThrowExceptionIfDamageIsZeroOrNegative(string message)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ortega", 0, 20), message);
            Assert.Throws<ArgumentException>(() => new Warrior("Ortega", -1, 20), message);
        }

        [TestCase("HP cannot be negative")]
        public void ValidIfThrowExceptionIfHPIsNegative(string message)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ortega", 10, -1), message);
        }

        [TestCase("Cannot make atacks with HP under or equal to 30")]
        public void ValidIfThrowExceptionIfHPIsUnderOrEqualToThirty(string message)
        {
            var testWarriorToAtack = new Warrior("Ortega", 10, 40);

            var testWarriorOne = new Warrior("Ortega", 10, 29);
            var testWarriorTwo = new Warrior("Ortega", 10, 30);

            Assert.Throws<InvalidOperationException>(() => testWarriorOne.Attack(testWarriorToAtack), message);
            Assert.Throws<InvalidOperationException>(() => testWarriorTwo.Attack(testWarriorToAtack), message);
        }

        [TestCase("Cannot atack enemy with HP under or equal to 30")]
        public void ValidIfThrowExceptionIfEnemyHPIsUnderOrEqualToThirty(string message)
        {
            var testWarriorOneToAtack = new Warrior("Ortega", 10, 30);
            var testWarriorTwoToAtack = new Warrior("Ortega", 10, 29);

            var testWarrior = new Warrior("Ortega", 10, 35);

            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarriorOneToAtack), message);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(testWarriorTwoToAtack), message);
        }

        [TestCase("Cannot make atacks with HP under Enemy`s Damage")]
        public void ValidIfThrowExceptionIfHPIsUnderEnemyDamage(string message)
        {
            var testWarriorToAtack = new Warrior("Ortega", 50, 40);

            var testWarriorOne = new Warrior("Ortega", 10, 35);

            Assert.Throws<InvalidOperationException>(() => testWarriorOne.Attack(testWarriorToAtack), message);
        }

        [TestCase("HP of the warrior doesnt decreases accurate")]
        public void ValidIfWarriorHPdecreasesAccurate(string message)
        {
            var testWarriorToAtack = new Warrior("Ortega", 35, 40);

            var testWarriorOne = new Warrior("Ortega", 20, 50);

            testWarriorOne.Attack(testWarriorToAtack);

            Assert.AreEqual(15, testWarriorOne.HP, message);
            Assert.AreEqual(20, testWarriorToAtack.HP, message);
        }

        [TestCase("If your damage is bigger than enemy`s HP it should decrease to zero")]
        public void ValidIfEnmyHPdecreasesToZeroIfYourDamageIsBigger(string message)
        {
            var testWarriorToAtack = new Warrior("Ortega", 35, 40);

            var testWarriorOne = new Warrior("Ortega", 50, 50);

            testWarriorOne.Attack(testWarriorToAtack);

            Assert.AreEqual(0, testWarriorToAtack.HP, message);
        }

    }
}