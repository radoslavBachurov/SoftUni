using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookSearched = Console.ReadLine();
            int libraryCapacity = int.Parse(Console.ReadLine());
            int counter = 0;

            while (true)
            {
                string bookChecking = Console.ReadLine();
                ++counter;
                if (bookSearched == bookChecking)
                {
                    Console.WriteLine($"You checked {counter-1} books and found it.");
                    break;
                }
                
                
                else if (counter == libraryCapacity)
                {
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;

                }
            }
        }
    }
}
