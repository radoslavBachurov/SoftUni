using System;

namespace Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            string index = FindingIndex(num1, num2, num3);
            Console.WriteLine(index);
        }

        private static string FindingIndex(int num1, int num2, int num3)
        {
            bool positive = true;

            if (num1 < 0)
                positive = false;

            if (num2 < 0 && positive == true)
                positive = false;
            else if (num2 < 0 && positive == false)
                positive = true;

            if (num3 < 0 && positive == false)
                positive = true;
            else if (num3 < 0 && positive == true)
                positive = false;

            if (num1 == 0 || num2 == 0 || num3 == 0)
                return "zero";

            else if (positive)

                return "positive";

            else
                return "negative";

        }
    }
}
