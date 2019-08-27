using System;

namespace Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double wight = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            double area = Calculate_Rectangle_Area(wight,heigth);
            Console.WriteLine(area);
        }

        private static double Calculate_Rectangle_Area(double wight,double height)
        {
            double area = wight * height;
            return area;
        }
    }
}
