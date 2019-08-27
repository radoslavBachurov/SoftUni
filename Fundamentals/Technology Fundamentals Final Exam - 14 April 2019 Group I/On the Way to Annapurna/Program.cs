using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> listOfItems = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArr = Regex.Split(input, @"->|,");
                string store = inputArr[1];

                if (inputArr[0] == "Add" && inputArr.Length == 3)
                {
                    if (!listOfItems.ContainsKey(store))
                    {
                        listOfItems.Add(store, new List<string>());
                    }

                    listOfItems[store].Add(inputArr[2]);
                }
                else if (inputArr[0] == "Add" && inputArr.Length > 3)
                {
                    if (!listOfItems.ContainsKey(store))
                    {
                        listOfItems.Add(store, new List<string>());
                    }

                    for (int i = 2; i < inputArr.Length; i++)
                    {
                        listOfItems[store].Add(inputArr[i]);
                    }
                }
                else
                {
                    if(listOfItems.ContainsKey(store))
                    {
                        listOfItems.Remove(store);
                    }
                }
            }

            Console.WriteLine("Stores list:");
            foreach (var store in listOfItems.OrderByDescending(x=>x.Value.Count).ThenByDescending(y=>y.Key))
            {
                Console.WriteLine($"{store.Key}");

                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
