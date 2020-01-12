using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    CheckingPeopleWhoCame(vip, regular);
                    break;
                }

                if (char.IsDigit(input[0]) && input.Length == 8)
                {
                    vip.Add(input);
                }
                else if (input.Length == 8)
                {
                    regular.Add(input);
                }
            }

            Console.WriteLine($"{vip.Count+regular.Count}");
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }

        private static void CheckingPeopleWhoCame(HashSet<string> vip, HashSet<string> regular)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                vip.Remove(input);
                regular.Remove(input);
            }
            return;
        }
    }
}
