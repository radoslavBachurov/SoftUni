using Databases;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Array should not accepts more than 16 elements",
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 89)]
        public void ValidIfArrayDontAcceptsMoreThanSixteenElements(string message, params int[] data)
        {
            Assert.That(() => new Database(data), Throws.InvalidOperationException, message);
        }

        [TestCase("Array must be 16 elements",
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6)]
        public void ValidIfArrayIsSixteenElements(string message, params int[] data)
        {
            var testDatabase = new Database(data);
            Assert.AreEqual(16, testDatabase.Count);
        }

        [TestCase("Add operation must put element at the next free cell",
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void ValidIfAddMethodIsPuttingElementsOneAfterAnother(string message, params int[] data)
        {
            var testDatabase = new Database(data);
            int[] copyOfArray = testDatabase.Fetch();

            for (int i = 0; i < data.Length; i++)
            {
                Assert.AreEqual(copyOfArray[i], data[i], message);
            }
        }

        [TestCase("Can not remove element from empty array")]
        public void ValidIfRemovingFromEmptyArrayNotPossible(string message)
        {
            var testDatabase = new Database(1);
            testDatabase.Remove();
            Assert.Throws<InvalidOperationException>(() => testDatabase.Remove(), message);
        }

        [TestCase("RemoveOperation dont remove element from the last index",
             1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void ValidIfRemovestheLastElement(string message, params int[] data)
        {
            var testDatabase = new Database(data);
            testDatabase.Remove();
            int[] copy = testDatabase.Fetch();

            for (int i = 1; i < 16; i++)
            {
                if (copy[i - 1] != i)
                {
                    Assert.Fail(message);
                }
            }

            Assert.Pass();
        }

        [TestCase("FetchMethod is not returning an array",
            1, 2, 3, 4, 5, 6)]
        public void ValidIfReturningAnArray(string message, params int[] data)
        {
            var testDatabase = new Database(data);

            var copy = testDatabase.Fetch();

            if (copy is Array)
            {
                Assert.Pass();
            }

            Assert.Fail(message);
        }


    }
}