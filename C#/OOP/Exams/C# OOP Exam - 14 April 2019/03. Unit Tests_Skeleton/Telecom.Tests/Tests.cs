namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [TestCase("Make cannot be null", null, "s8")]
        [TestCase("Make cannot be Empty", "", "s8")]
        public void IfValidShouldReturnExceptionWhenMakeReceiveNullOrEmpty(string message, string make, string model)
        {
            Assert.That(() => new Phone(make, model), Throws.ArgumentException, message);
        }

        [TestCase("Model cannot be null", "Samsung", null)]
        [TestCase("Model cannot be Empty", "Sony", "")]
        public void IfValidShouldReturnExceptionWhenModelReceiveNullOrEmpty(string message, string make, string model)
        {
            Assert.That(() => new Phone(make, model), Throws.ArgumentException, message);
        }

        [TestCase("Constructor doesnt set up Make or Model correctly", "Samsung", "s8")]
        [TestCase("Constructor doesnt set up Make  or Model correctly", "Sony", "e8")]
        public void IfValidShouldReturnExceptionWhenMakeOrModelAreNotSetUpCorrectly(string message, string make, string model)
        {
            var testPhone = new Phone(make, model);
            Assert.AreEqual(testPhone.Make, make, message);
            Assert.AreEqual(testPhone.Model, model, message);
        }

        [TestCase("Cannot have two persons with the same name in phonebook")]
        public void IfValidShouldReturnExceptionWhenReceiveTwoPeopleWithSameName(string message)
        {
            var testPhone = new Phone("samsung", "s8");
            testPhone.AddContact("Ivan", "08835");
            Assert.Throws<InvalidOperationException>(() => testPhone.AddContact("Ivan", "92837432"),message);
        }

        [TestCase("Cannot call person that doesnt exist")]
        public void IfValidShouldReturnExceptionWhenTryToCallPersonThatDontExists(string message)
        {
            var testPhone = new Phone("samsung", "s8");
            testPhone.AddContact("Ivan", "08835");
            Assert.Throws<InvalidOperationException>(() => testPhone.Call("Stoyo"), message);
        }

        [TestCase("Phone Doesnt call the correct Number")]
        public void IfValidShouldReturnExceptionWhenNumberDoesntAccordToThisPerson(string message)
        {
            var testPhone = new Phone("samsung", "s8");
            testPhone.AddContact("Ivan", "08835");
            string returnMessage = testPhone.Call("Ivan");
            Assert.AreEqual("Calling Ivan - 08835...", returnMessage,message);
        }

        [TestCase("Count Property dont return correct count")]
        public void IfValidShouldReturnExceptionCountReturnIsWrong(string message)
        {
            var testPhone = new Phone("samsung", "s8");
            testPhone.AddContact("Ivan", "08835");
            testPhone.AddContact("Gosho", "0883453435");
            testPhone.AddContact("Pesho", "088534535");
            
            Assert.AreEqual(3,testPhone.Count);
        }
    }
}