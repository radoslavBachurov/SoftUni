using ExtendedDatabases;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] shortData;
        private Person[] accurateData;

        [SetUp]
        public void Setup()
        {
            shortData = new Person[5]
            {
            new Person(12345678,"Arwen")  ,
            new Person(98756732,"Mephisto"),
            new Person(98854432,"Diablo"),
            new Person(34565432,"Cyborg"),
            new Person(98765763,"DoomsDay")
            };

            accurateData = new Person[16]
            {
             new Person(12345678,"Arwen")  ,
            new Person(98756732,"Mephisto"),
            new Person(98854432,"Diablo"),
            new Person(34565432,"Cyborg"),
            new Person(98765763,"DoomsDay"),
            new Person(1234563454,"WonderWoman")  ,
            new Person(987636732,"Superman"),
            new Person(987657567,"Bloodkill"),
            new Person(9876947632,"Jokera"),
            new Person(9876579022,"Batman"),
            new Person(1232050678,"Ivan")  ,
            new Person(982346432,"Bobo"),
            new Person(9879904432,"Mariq"),
            new Person(989283432,"Mimi"),
            new Person(98798332,"Pena"),
            new Person(9870956432,"Gosho"),
            };
        }

        [TestCase("Constructor not adding people and increase count correctly")]
        public void ValidIfInternalArrayLenghtIsSixteen(string message)
        {
            var database = new ExtendedDatabase(accurateData);
            int lenght = database.Count;
            Assert.AreEqual(16, lenght, message);
        }

        [TestCase("Provided data length should be in range[0..16]!")]
        public void ValidIfThrowsExceptionWhenAddingArrayBiggerThanSixteenElements(string message)
        {
            var people = new Person[17];
            Assert.That(() => new ExtendedDatabase(people), Throws.ArgumentException);
        }

        [TestCase("Array's capacity must be exactly 16 integers!")]
        public void ValidIfThrowsExceptionWhenTryToAddMoreThanSixteenElements(string message)
        {
            var database = new ExtendedDatabase(accurateData);
            Assert.That(() => database.Add(new Person(2349823094, "Test")), Throws.InvalidOperationException, message);
        }

        [TestCase("There is already user with this username!")]
        public void ValidifAddMethodDontAcceptsTwoPeopleWithSameName(string message)
        {
            var database = new ExtendedDatabase(shortData);
            Assert.That(() => database.Add(new Person(2349823094, "Arwen")), Throws.InvalidOperationException, message);
        }


        [TestCase("There is already user with this ID!")]
        public void ValidifAddMethodDontAcceptsTwoPeopleWithSameID(string message)
        {
            var database = new ExtendedDatabase(shortData);
            Assert.That(() => database.Add(new Person(98756732, "Test")), Throws.InvalidOperationException, message);
        }

        [TestCase("Cant remove element from empty string")]
        public void ValidifRemoveMethodDontWorkOnEmptyString(string message)
        {
            var database = new ExtendedDatabase(shortData);
            for (int i = 0; i < 5; i++)
            {
                database.Remove();
            }
            Assert.That(() => database.Remove(), Throws.InvalidOperationException, message);

        }

        [TestCase("Method doesnt remove people correctly")]
        public void ValidifRemoveMethodRemovesPeopleCorrectly(string message)
        {
            var database = new ExtendedDatabase(shortData);
            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }
            Assert.AreEqual(3, database.Count);
            var person = database.FindByUsername("Arwen");
            Assert.AreEqual("Arwen", person.UserName);
        }

        [TestCase("Username parameter cant be null or empty!")]
        public void ValidIfThrowsExceptionWhenTryingToFindPersonWhoIsEmptyOrNull(string message)
        {
            var database = new ExtendedDatabase(shortData);

            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException, message);
            Assert.That(() => database.FindByUsername(""), Throws.ArgumentNullException, message);
        }

        [TestCase("Input must be existing user")]
        public void ValidIfThrowsExceptionWhenTryingToFindPersonWhoDontExist(string message)
        {
            var database = new ExtendedDatabase(shortData);

            Assert.That(() => database.FindByUsername("Mario"), Throws.InvalidOperationException, message);
        }

        [TestCase("Id should be a positive number!")]
        public void ValidIfThrowsExceptionWhenTryingtOfFindPersonWithNegativeID(string message)
        {
            var database = new ExtendedDatabase(shortData);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-0876757337));
        }

        [TestCase("ID number must exist in the list")]
        public void ValidIfThrowsExceptionWhenTryingToFindPersonWithNonExistingId(string message)
        {
            var database = new ExtendedDatabase(shortData);

            Assert.That(() => database.FindById(123), Throws.InvalidOperationException, message);
        }

        [TestCase("Add method dont add people correctly")]
        public void AddMethodShouldIncreaseTheCountAndAddPersonCorrectly(string message)
        {
            var testDatabase = new ExtendedDatabase(shortData);
            testDatabase.Add(new Person(739319304, "Martincho"));
            Assert.AreEqual(6, testDatabase.Count, message);
        }

        [TestCase("Find by Name Method dont work correctly")]
        public void FindByUserNameMethodShouldWorkCorrectly(string message)
        {
            var database = new ExtendedDatabase(shortData);
            var actualPerson = database.FindByUsername("Arwen");
            Assert.AreEqual(shortData[0], actualPerson, message);
        }

        [TestCase("Find By Id Method Should Work Correctlly")]
        public void FindByIdMethodShouldWorkCorrectly(string message)
        {
            var database = new ExtendedDatabase(shortData);
            var targetPerson = database.FindById(12345678);
            Assert.AreEqual(shortData[0], targetPerson, message);
        }
    }

}