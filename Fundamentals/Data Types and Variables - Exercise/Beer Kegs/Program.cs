using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countKegs = int.Parse(Console.ReadLine());
            double max = double.MinValue;
            string biggestKeg = string.Empty;

            for (int i = 0; i < countKegs; i++)
            {
                string brand = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * (Math.Pow(radius, 2) * height);

                if(volume>max)
                {
                    max = volume;
                    biggestKeg = brand;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
