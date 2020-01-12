using System;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            bool toe = false;

            for (int ch = 1; ch <= number; ch++)
            {
                int currentNumber = ch;
                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }
                toe = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", ch, toe);
                sum = 0;
            }

        }
    }
}
