using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tables = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double wight = double.Parse(Console.ReadLine());
            double areapok = tables*((lenght + 0.60) * (wight + 0.60));
            double areakare = tables*((lenght / 2) * (lenght / 2));
          
            double dolarcenapok = areapok * 7;
            double dolarcenakare = areakare * 9;
            double dolarprice = dolarcenakare + dolarcenapok;
            double dolarkamlev = dolarprice * 1.85;
            Console.WriteLine($"{dolarprice:f2} USD");
            Console.WriteLine($"{dolarkamlev:f2} BGN");
        }
    }
}
