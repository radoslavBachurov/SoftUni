using System;

namespace Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            ClosestPoint(x, y, x1, y1);
        }

        private static void ClosestPoint(double x, double y, double x1, double y1)
        {
            double first = Math.Abs(x) + Math.Abs(y);
            double second = Math.Abs(x1) + Math.Abs(y1);

            if (first < second)
                Console.WriteLine($"({x}, {y})");
            else if (second < first)
                Console.WriteLine($"({x1}, {y1})");
            else
                Console.WriteLine($"({x}, {y})");
        }
    }
}
