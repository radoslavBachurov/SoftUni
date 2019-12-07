namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark testParking;
        private Car testCarOne;
        private Car testCarTwo;

        [SetUp]
        public void Setup()
        {
            testParking = new SoftPark();
            testCarOne = new Car("Ferrari", "vt3395vt");
            testCarTwo = new Car("Opel", "sf5555vt");
        }

        [TestCase("Parking Spot must exist")]
        public void ValidIfThrowExceptionWhenInvalidParkingNameIsTaken(string message)
        {
            Assert.Throws<ArgumentException>(() => testParking.ParkCar("F3", testCarOne), message);
        }

        [TestCase("Parking Spot must be free")]
        public void ValidIfThrowExceptionWhenParkingSpotIsTaken(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            Assert.Throws<ArgumentException>(() => testParking.ParkCar("B4", testCarTwo), message);
        }

        [TestCase("Car already exist")]
        public void ValidIfThrowExceptionWhenSameCarTryToPark(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            Assert.Throws<InvalidOperationException>(() => testParking.ParkCar("B3", testCarOne), message);
        }

        [TestCase("Method ParkCar should return accurate message")]
        public void ValidIfReturnsAccurateMessageWhenCarIsParked(string message)
        {
            string returnedMessage = testParking.ParkCar("B4", testCarOne);
            string accurateMessage = $"Car:{testCarOne.RegistrationNumber} parked successfully!";

            Assert.AreEqual(returnedMessage, accurateMessage);
        }

        [TestCase("Method ParkCar should put car in correct spot")]
        public void ValidIfCarIsParkedInCorrectSpot(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            bool parkedCar = testParking.Parking["B4"] == testCarOne;

            Assert.IsTrue(parkedCar);
        }

        [TestCase("Method RemoveCar should accept only existing car spots")]
        public void ValidIfThrowsExceptionWhenUnexistingSpotIsTaken(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            Assert.Throws<ArgumentException>(() => testParking.RemoveCar("F3", testCarOne), message);
        }

        [TestCase("Method RemoveCar should accept only existing cars")]
        public void ValidIfThrowsExceptionWhenUnexistingCarIsTaken(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            Assert.Throws<ArgumentException>(() => testParking.RemoveCar("B4", testCarTwo), message);
        }

        [TestCase("Method RemoveCar should return accurate message")]
        public void ValidIfReturnsAccurateMessageWhenCarIsRemoved(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            string returnedMessage = testParking.RemoveCar("B4", testCarOne);
            string accurateMessage = $"Remove car:{testCarOne.RegistrationNumber} successfully!";

            Assert.AreEqual(returnedMessage, accurateMessage);
        }

        [TestCase("After removing a car spot spot must be null")]
        public void ValidIfSpotIsNullAfterRemovingCar(string message)
        {
            testParking.ParkCar("B4", testCarOne);
            testParking.RemoveCar("B4", testCarOne);


            Assert.AreEqual(null, testParking.Parking["B4"]);
        }
    }
}