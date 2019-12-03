using NUnit.Framework;
//using FightingArena;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena testArena;
        [SetUp]
        public void Setup()
        {
            testArena = new Arena();
        }

        [TestCase("Enroll Method dont add warriors correctly")]
        public void IfValidEnrollMethodWorksCorrectly(string message)
        {
            var testWarriorOne = new Warrior("Ortega", 10, 40);
            var testWarriorTwo = new Warrior("Ortega", 14, 50);
            var testWarriorThree = new Warrior("BaiStoyo", 12, 55);

            testArena.Enroll(testWarriorOne);
            testArena.Enroll(testWarriorThree);

            Assert.Throws<InvalidOperationException>(() => testArena.Enroll(testWarriorTwo), message);
            Assert.AreEqual(2, testArena.Count);
        }

        [TestCase("When atacker is null must throw exception")]
        public void IfValidShouldThrowExceptionWhenAtackerIsNull(string message)
        {
            var testWarriorOne = new Warrior("Ortega", 10, 40);

            testArena.Enroll(testWarriorOne);

            Assert.Throws<InvalidOperationException>(() => testArena.Fight("Ivan","Ortega"), message);
        }

        [TestCase("When defender is null must throw exception")]
        public void IfValidShouldThrowExceptionWhenDefenderIsNull(string message)
        {
            var testWarriorOne = new Warrior("Ortega", 10, 40);

            testArena.Enroll(testWarriorOne);

            Assert.Throws<InvalidOperationException>(() => testArena.Fight("Ortega", "Ivan"), message);
        }

        [TestCase("Warriors getter is not working correctly")]
        public void IfValidShouldReturnCollectionOfWarriors(string message)
        {
            var testWarriorOne = new Warrior("Ortega", 10, 40);

            testArena.Enroll(testWarriorOne);
            var warriors = testArena.Warriors;

            Assert.True(warriors is IReadOnlyCollection<Warrior>, message);
        }

        [TestCase("Arena Method Fight Dont Work Correctly")]
        public void ValidIfArenaMethodFightShouldWorkCorrectly(string message)
        {
            var testWarriorTwo = new Warrior("Ortega", 14, 50);
            var testWarriorThree = new Warrior("BaiStoyo", 12, 55);

            testArena.Enroll(testWarriorTwo);
            testArena.Enroll(testWarriorThree);
            testArena.Fight("Ortega", "BaiStoyo");
            Assert.AreEqual(38, testWarriorTwo.HP);
            Assert.AreEqual(41, testWarriorThree.HP);
        }
    }
}
