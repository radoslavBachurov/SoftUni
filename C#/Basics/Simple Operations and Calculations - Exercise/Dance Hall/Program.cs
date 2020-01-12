using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double wight = double.Parse(Console.ReadLine());
            double sidewardrobe = double.Parse(Console.ReadLine());
            double areawardobe = sidewardrobe * sidewardrobe;
            double bench = (lenght * wight) / 10;
            double dancer = 0.004;
            double freespaceneeded = 0.7;
            double freespace = (lenght * wight) - (areawardobe + bench);
            double numberdancers = freespace/(freespaceneeded+dancer);
             Console.WriteLine($"{Math.Floor(numberdancers)}");
         
             

        }
    }
}
