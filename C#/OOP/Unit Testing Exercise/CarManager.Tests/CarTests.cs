using NUnit.Framework;
using CarManager;
using System.Reflection;
using System.Linq;
using System;
using System.Net.Sockets;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Constructor doesnt work correctly")]
        public void ValidIfConstructorsWorksCorrectly(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 7.6, 100.7);
            Assert.AreEqual(testCar.FuelConsumption, 7.6, message);
            Assert.AreEqual(testCar.Make, "Ferrari", message);
            Assert.AreEqual(testCar.FuelCapacity, 100.7, message);
            Assert.AreEqual(testCar.Model, "Spyder", message);
            Assert.AreEqual(testCar.FuelAmount, 0, message);
        }

        [TestCase("Doesnt throw exception if make is null or empty")]
        public void ValidIfThrowsExceptionIfMakeIsNullOrEmpty(string message)
        {
            Assert.That(() => new Car("", "Spyder", 7.6, 100.7), Throws.ArgumentException, message);
            Assert.That(() => new Car(null, "Spyder", 7.6, 100.7), Throws.ArgumentException, message);
        }

        [TestCase("Doesnt throw exception if model is null or empty")]
        public void ValidIfThrowsExceptionIfModelIsNullOrEmpty(string message)
        {
            Assert.That(() => new Car("Ferrari", null, 7.6, 100.7), Throws.ArgumentException, message);
            Assert.That(() => new Car("Ferrari", "", 7.6, 100.7), Throws.ArgumentException, message);
        }

        [TestCase("Doesnt throw exception if fuel consumption is zero or negative")]
        public void ValidIfThrowsExceptionIfFuelConsumtionIsZeroOrNegative(string message)
        {
            Assert.That(() => new Car("Ferrari", "Spyder", 0, 100.7), Throws.ArgumentException, message);
            Assert.That(() => new Car("Ferrari", "Spyder", -3, 100.7), Throws.ArgumentException, message);
        }

        [TestCase("Doesnt throw exception if fuelCapacity is zero or negative")]
        public void ValidIfThrowsExceptionIfFuelIsZeroOrNegative(string message)
        {
            Assert.That(() => new Car("Ferrari", "Spyder", 6.4, -100), Throws.ArgumentException, message);
            Assert.That(() => new Car("Ferrari", "Spyder", 6.4, 0), Throws.ArgumentException, message);
        }

        [TestCase("Doesnt throw exception if fuelAmount is negative")]
        public void ValidIfThrowsExceptionIfFuelAmountIsNegative(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 6.4, 100);
            try
            {
                typeof(Car).GetProperty("FuelAmount").SetValue(testCar, -100);
                Assert.Fail(message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "Fuel amount cannot be negative!")
                {
                    Assert.Pass();
                }
            }
            Assert.Fail();
        }

        [TestCase("The Input of refuel method cannot be zero or negative")]
        public void ValidIfThrowsExceptionWhenInputIsZeroOrNegative(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 6.4, 100);
            Assert.That(() => testCar.Refuel(0), Throws.ArgumentException, message);
            Assert.That(() => testCar.Refuel(-20), Throws.ArgumentException, message);
        }

        [TestCase("The Refuel method doesnt add fuel correctly")]
        public void ValidIfRefuelMethodAddsFuelCorrectly(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 6.4, 100);
            testCar.Refuel(30);
            Assert.AreEqual(testCar.FuelAmount, 30, message);
        }

        [TestCase("When refueling and fuel amount is bigger than fuel capacity" +
            "than fuel amount must be equal to fuel capacity")]
        public void ValidIfFuelAmountIsEqualToFuelCapacityWhenFualAmountIsBigger(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 6.4, 100);
            testCar.Refuel(120);
            Assert.AreEqual(testCar.FuelAmount, 100, message);
        }

        [TestCase("When using Drive Method" +
            " and Fuel needed is bigger than fuel amount you cant drive")]
        public void ValidWhenThrowExceptionWhenFuelNeededIsBiggerThanFuelAmount(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 6.4, 100);
            Assert.Throws<InvalidOperationException>(() => testCar.Drive(30), message);
        }

        [TestCase("When using Drive Method" +
           "FuelAmount doesnt decreases correctly ")]
        public void ValidIfFuelAmountDecreasesCorrectlyWhenDriving(string message)
        {
            var testCar = new Car("Ferrari", "Spyder", 7 , 100);
            testCar.Refuel(100);
            testCar.Drive(30);
            double fuelNeeded = (30 / 100.0) * 7.0;
            double left = 100 - fuelNeeded;

            Assert.AreEqual(left, testCar.FuelAmount,message);
        }
    }
}