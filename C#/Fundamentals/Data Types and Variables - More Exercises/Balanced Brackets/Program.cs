using System;

namespace Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int countOpening = 0;
            int countClosing = 0;
            int secondOpeningCount = 0;
            int secondClosingCount = 0;
            bool lastOpen = false;
            string input = string.Empty;

            for (int i = 0; i < number; i++)
            {
                input = Console.ReadLine();
                if (input != "(" && secondOpeningCount == 1)
                    secondOpeningCount = 0;
                if (input != ")" && secondClosingCount == 1)
                    secondClosingCount = 0;

                if (input == "(")
                {
                    countOpening++;
                    secondOpeningCount++;
                    lastOpen = true;
                    if (secondOpeningCount == 2)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
                else if (input == ")")
                {
                    countClosing++;
                    secondClosingCount++;
                    lastOpen = false;
                    if (secondClosingCount == 2)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
} }

            if (countOpening == countClosing && !lastOpen)
                Console.WriteLine("BALANCED");
            else
                Console.WriteLine("UNBALANCED");
        }
    }
}
