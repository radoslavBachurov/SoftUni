using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle testMotorOne;
        private UnitMotorcycle testMotorTwo;
        private UnitRider testRiderOne;
        private UnitRider testRiderTwo;
        private RaceEntry TestRaceEntry;

        [SetUp]
        public void Setup()
        {
            testMotorOne = new UnitMotorcycle("Harley", 800, 1600.5);
            testMotorTwo = new UnitMotorcycle("Ducati", 1000, 1505.5);
            testRiderOne = new UnitRider("Marlboro", testMotorOne);
            testRiderTwo = new UnitRider("Barry", testMotorTwo);
            TestRaceEntry = new RaceEntry();
        }

        [TestCase("Name cannot be null")]
        public void ValidIfThrowExceptionWhenTryToSetValueNameNull(string message)
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, testMotorOne), message);
        }

        [TestCase("Cannot Add Rider that is null")]
        public void ValidIfThrowExceptionWhenTryToAddNullDriver(string message)
        {
            try
            {
                Assert.Throws<InvalidOperationException>(() => TestRaceEntry.AddRider(null), message);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Rider cannot be null.");
            }
        }

        [TestCase("Cannot have two riders with same name")]
        public void ValidIfThrowExceptionWhenTrySameDrivers(string message)
        {
            TestRaceEntry.AddRider(testRiderOne);
            try
            {
                Assert.Throws<InvalidOperationException>(() => TestRaceEntry.AddRider(testRiderOne), message);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, string.Format("Rider {0} is already added.", testRiderOne.Name), message);
            }
        }


        [TestCase("Output message drom adding is not correct")]
        public void ValidIfMessageFromAddingRiderIsCorrect(string message)
        {
            string result = TestRaceEntry.AddRider(testRiderOne);
            Assert.AreEqual("Rider Marlboro added in race.", result,message);
        }

        [TestCase("Count not correct")]
        public void ValidIfCountIsCorrect(string message)
        {
            TestRaceEntry.AddRider(testRiderOne);
            TestRaceEntry.AddRider(testRiderTwo);
            Assert.AreEqual(TestRaceEntry.Counter, 2,message);
        }

        [TestCase("Cannot Start Race with under min participants")]
        public void ValidIfThrowExceptionWhenTryToStartRaceWithUnderMinParticipants(string message)
        {
            TestRaceEntry.AddRider(testRiderOne);
            Assert.Throws<InvalidOperationException>(() => TestRaceEntry.CalculateAverageHorsePower(),message);
        }

        [TestCase("Average HP not correct")]
        public void ValidIfAverrageHPisCorrect(string message)
        {
            TestRaceEntry.AddRider(testRiderOne);
            TestRaceEntry.AddRider(testRiderTwo);
            double average = TestRaceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(average, 900);
        }
    }
}