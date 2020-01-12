using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> females = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int numberMatches = 0;

            while (males.Any() && females.Any())
            {
                int maleValue = males.Peek();
                int femaleValue = females.Peek();

                if (femaleValue <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (maleValue <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (maleValue % 25 == 0)
                {
                    males.Pop();
                    if (males.Any())
                    {
                        males.Pop();
                    }
                    continue;
                }
                if (femaleValue % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (maleValue == femaleValue)
                {
                    females.Dequeue();
                    males.Pop();
                    numberMatches++;

                }
                else
                {
                    females.Dequeue();
                    maleValue -= 2;
                    males.Pop();
                    males.Push(maleValue);
                }
            }

            Console.WriteLine($"Matches: {numberMatches}");

            if(males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
