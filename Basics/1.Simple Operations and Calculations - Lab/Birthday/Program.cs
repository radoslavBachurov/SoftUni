using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double wide = double.Parse(Console.ReadLine());
            double long1 = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double area = wide * long1 * height;
            double cmtodm = area * 0.001;
            double usedarea = percent * 0.01;
            double litresneeded = cmtodm * (1 - usedarea);
            Console.WriteLine($"{litresneeded:f3}");
        }

    }
}
