using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> test = new Dictionary<string, string>();

            test.Add("baba", "haha");
            test.Add("rara", "dada");
            test.Add("fafo", "rado");

            test.Remove("rado");

            foreach (var item in test.Where(x => x.Value == "rado").ToList())
            {
                test.Remove(item.Key);
            }
            foreach (var item in test)
            {
                Console.WriteLine($"{item.Key}----{item.Value}");
            }
        }
    }
}
