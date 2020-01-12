using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int number2 = 1;

            while (number >= number2)
            {
                Console.WriteLine(number2);
                number2 = number2 * 2 + 1;
            }

        }
    }
}
