using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberChars = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < numberChars; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sum += symbol;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
