using System;

namespace Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringNumber = Console.ReadLine();
            int lenght = stringNumber.Length;
            double[] arrayNumber = new double[lenght];
            int number = int.Parse(stringNumber);
            int orignNumber = number;
            int sum = 1;
            int totalSum=0;

            for (int i = 0; i < lenght; i++)
            {
                double lastDigit = number % 10.0;
                arrayNumber[i] = lastDigit;
                number /= 10;
                for (int t = 1; t <= arrayNumber[i]; t++)
                {
                    sum *= t;
                }
                totalSum += sum;
                sum = 1;
            }
            if (totalSum == orignNumber)
                Console.WriteLine("yes");

            else if(totalSum != orignNumber)
                Console.WriteLine("no");









        }
    }
}
