using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inches_to_centimetres
{
    class Program
    {
        static void Main(string[] args)
        {
            double centimetresperinch = 2.54;
            double inches = double.Parse(Console.ReadLine());
            double answer = inches * centimetresperinch;
            Console.WriteLine($"{answer:f2}");
        }
    }
}
