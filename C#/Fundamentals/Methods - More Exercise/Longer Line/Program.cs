using System;

namespace Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] longerLine = FindingLongerLine();

            double first = Math.Abs(longerLine[0]) + Math.Abs(longerLine[1]);
            double second = Math.Abs(longerLine[2]) + Math.Abs(longerLine[3]);

            if (first < second)
                Console.WriteLine($"({longerLine[0]}, {longerLine[1]})({longerLine[2]}, {longerLine[3]})");
            else if (second < first)
                Console.WriteLine($"({longerLine[2]}, {longerLine[3]})({longerLine[0]}, {longerLine[1]})");
            else
                Console.WriteLine($"({longerLine[0]}, {longerLine[1]})({longerLine[2]}, {longerLine[3]})");
        }

        private static double[] FindingLongerLine()
        {
            double firstLenght = 0;
            double secondLenght = 0;
            double[] lineTwo = new double[4];
            double[] lineOne = new double[4];

            for (int i = 0; i < 2; i++)
            {
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());

                if (i == 0)
                {
                    lineOne[0] = x;
                    lineOne[1] = y;
                    lineOne[2] = x1;
                    lineOne[3] = y1;
                    firstLenght = FirstLine(x, y, x1, y1);
                }
                else
                {
                    lineTwo[0] = x;
                    lineTwo[1] = y;
                    lineTwo[2] = x1;
                    lineTwo[3] = y1;
                    secondLenght = SecondLine(x, y, x1, y1);
                }
            }

            if (firstLenght > secondLenght)
                return lineOne;
            else if (secondLenght > firstLenght)
                return lineTwo;
            else
                return lineOne;
        }
        private static double SecondLine(double x, double y, double x1, double y1)
        {

            double lenght = Math.Sqrt(Math.Pow((x1 - x), 2) + Math.Pow((y1 - y), 2));
            return lenght;
        }

        private static double FirstLine(double x, double y, double x1, double y1)
        {
            double lenght = Math.Sqrt(Math.Pow((x1 - x), 2) + Math.Pow((y1 - y1), 2));
            return lenght;
        }
    }
}
