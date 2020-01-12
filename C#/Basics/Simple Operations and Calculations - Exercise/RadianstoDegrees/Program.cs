using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadianstoDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double Rad = double.Parse(Console.ReadLine());
            double radtodeg = Rad * 180 / Math.PI;
            double roundeddeg = Math.Round(radtodeg);
            Console.WriteLine(roundeddeg);
        }
    }
}
