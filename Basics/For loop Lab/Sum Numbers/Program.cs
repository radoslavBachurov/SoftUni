using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digitsum = 0;

            for (int i = 0; i < number; i++)
            {
                 int digit = int.Parse(Console.ReadLine());
                digitsum += digit;
            }
            Console.WriteLine(digitsum);
        }
    }
}
