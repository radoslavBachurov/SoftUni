using Aquariums;
namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [TestCase("Test should work correctly")]
        public void ValidIfConstructorWorksCorrectly(string message)
        {
            var testAquarium = new Aquarium("Pesho", 23);

            Assert.AreEqual(testAquarium.Capacity, 23, message);
            Assert.AreEqual(testAquarium.Name, "Pesho", message);
        }

        [TestCase("Name Cannot be null or empty")]
        public void ValidIfThrowExceptionIfNameIsNullOrEmpty(string message)
        {

            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 23));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 23));
        }

        [TestCase("Capacity cannot be negative")]
        public void ValidIfThrowExceptionIfCapacityIsNegative(string message)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("pesho", -23));
            Assert.Throws<ArgumentException>(() => new Aquarium("ivan", -1));
        }

        [TestCase("Cannot put fished over capacity")]
        public void ValidIfThrowExceptionIfTryToPutFishOverTheCapacity(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishTwo = new Fish("Gosho");
            var testFishthree = new Fish("Shile");

            testAquarium.Add(testFishOne);
            testAquarium.Add(testFishTwo);

            Assert.Throws<InvalidOperationException>(() => testAquarium.Add(testFishthree), message);

        }

        [TestCase("Count not correct")]
        public void ValidIfCountIsCorrect(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishTwo = new Fish("Gosho");

            testAquarium.Add(testFishOne);


            Assert.AreEqual(testAquarium.Count, 1);

        }

        [TestCase("Cannot remove inexicted fish")]
        public void ValidIfThrowExceptionIfTryToRemoveNonExistedFish(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishTwo = new Fish("Gosho");
            var testFishthree = new Fish("Shile");

            testAquarium.Add(testFishOne);
            testAquarium.Add(testFishTwo);

            Assert.Throws<InvalidOperationException>(() => testAquarium.RemoveFish("blaa"), message);

        }

        [TestCase("Remove command should remove the fish")]
        public void ValidIfRemoveCommandRemovesTheFish(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishTwo = new Fish("Gosho");
            var testFishthree = new Fish("Shile");

            testAquarium.Add(testFishOne);
            testAquarium.Add(testFishTwo);
            testAquarium.RemoveFish("Ivan");

            Assert.Throws<InvalidOperationException>(() => testAquarium.RemoveFish("Ivan"), message);

        }

        [TestCase("Sell fish cannot remove non existed fish")]
        public void ValidIfThrowExceptionWhenTryToSellNonExistedFish(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishTwo = new Fish("Gosho");
            var testFishthree = new Fish("Shile");

            testAquarium.Add(testFishOne);
            testAquarium.Add(testFishTwo);
            testAquarium.RemoveFish("Ivan");

            Assert.Throws<InvalidOperationException>(() => testAquarium.SellFish("baba"), message);

        }

        [TestCase("Sell fish Should return accurate fish")]
        public void ValidIfSellFishReturnAccurateFish(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishTwo = new Fish("Gosho");
            var testFishthree = new Fish("Shile");

            testAquarium.Add(testFishOne);
            testAquarium.Add(testFishthree);
            testAquarium.RemoveFish("Ivan");

            var newFish = testAquarium.SellFish("Shile");

            Assert.AreEqual(newFish.Name, "Shile");
            Assert.IsFalse(newFish.Available);
        }

        [TestCase("Report not working correctly")]
        public void ValidIfRepororectlytWorksC(string message)
        {
            var testAquarium = new Aquarium("Pesho", 2);
            var testFishOne = new Fish("Ivan");
            var testFishthree = new Fish("Shile");

            testAquarium.Add(testFishOne);
            testAquarium.Add(testFishthree);

            string correct = "Fish available at Pesho: Ivan, Shile";
            Assert.AreEqual(correct, testAquarium.Report());
            //string fishNames = string.Join(", ", this.fish.Select(f => f.Name));
            //string report = $"Fish available at {this.Name}: {fishNames}";
        }
    }
}
