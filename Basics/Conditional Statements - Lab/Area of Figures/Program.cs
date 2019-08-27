using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string square = Console.ReadLine();
            
            double area = 0;

            if(square == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
                
            }
            else if(square == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
                
            }
            else if(square == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.PI * r * r;
            }
            else if (square == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                area = side * height/2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}
