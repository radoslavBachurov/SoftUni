using System;
using System.Linq;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int count = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            AddItems<string>(input, addCollection);
            AddItems<string>(input, addRemoveCollection);
            AddItems<string>(input, myList);

            RemoveItems<string>(input, addRemoveCollection, count);
            RemoveItems<string>(input, myList, count);

        }

        public static void AddItems<T>(T[] input, IAddCollection<T> collection)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{collection.Add(input[i])}" + " ");
            }
            Console.WriteLine();
        }

        public static void RemoveItems<T>(T[] input, IAddRemoveCollection<T> collection, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{collection.Remove()}" + " ");
            }
            Console.WriteLine();
        }
    }
}
