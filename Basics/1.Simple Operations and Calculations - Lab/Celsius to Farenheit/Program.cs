using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_to_Farenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double ctof = celsius * 1.8 + 32;
            Console.WriteLine("{0:f2}",ctof);
        }
    }
}
