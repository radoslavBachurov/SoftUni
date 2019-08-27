using System;

namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int[] numbers = new int[3];

            while (true)
            {

                numbers[counter] = int.Parse(Console.ReadLine());
                if (counter == 2)
                    break;
                counter++;
            }
            int max = Math.Max(Math.Max(numbers[0], numbers[1]),numbers[2]);
            int min = Math.Min(Math.Min(numbers[0], numbers[1]),numbers[2]);
            int middle = (numbers[0] + numbers[1] + numbers[2]) - (min + max);
            Console.WriteLine($"{max}");
            Console.WriteLine($"{middle}");
            Console.WriteLine($"{min}");




        }
    }
}
