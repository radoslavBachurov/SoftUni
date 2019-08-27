using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (true)
            {
                string command = Console.ReadLine();
                bool prime = true;
                if (command == "stop")
                {
                    break;
                }
                int number = int.Parse(command);
                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                if (number == 1)
                {
                    nonPrimeSum += number;
                }
               
                else
                {
                    for (int i = number; i >= 2; i--)
                    {
                        if (number % i == 0 && number != i)
                        {
                            nonPrimeSum += number;
                            prime = false;
                            break;

                        }
                    }
                    if (prime == true)
                    {
                        primeSum += number;
                    }

                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
