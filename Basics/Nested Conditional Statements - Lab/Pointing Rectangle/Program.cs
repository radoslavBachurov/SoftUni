using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointing_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());//2
            double y1 = double.Parse(Console.ReadLine());//-3
            double x2 = double.Parse(Console.ReadLine());//12
            double y2 = double.Parse(Console.ReadLine());//3
            double x = double.Parse(Console.ReadLine());//11
            double y = double.Parse(Console.ReadLine());//-3,5

            bool inside = x >= x1 && x <= x2 && y >= y1 && y <= y2;
           

            if (inside)
            {
                Console.WriteLine("Inside");
            }
            else 
            {
                Console.WriteLine("Outside");
            }
                


        }
    }
}
