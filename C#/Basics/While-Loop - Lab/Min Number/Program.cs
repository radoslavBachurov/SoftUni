using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDigits = int.Parse(Console.ReadLine());
            int countDigits = 1;
            double min = int.MaxValue;

            while (numberDigits >= countDigits)
            {
                double Digits = double.Parse(Console.ReadLine());
                countDigits++;

                if (Digits < min)
                {
                    min = Digits;
                }
            }
            Console.WriteLine(min);

        }
    }
}
