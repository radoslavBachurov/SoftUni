using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_in_Range100
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool range = number > 100 || number < 1;
            while (range)
            {
                Console.WriteLine("Invalid number!");
                number = int.Parse(Console.ReadLine());
                 range = number > 100 || number < 1;
            }
            Console.WriteLine($"The number is: {number}");
        }
    }
}
