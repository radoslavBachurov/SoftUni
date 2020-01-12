using System;
using System.Linq;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int length = num.Length;
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += int.Parse(num[i].ToString());
            }
            Console.WriteLine(sum);






        }
    }
}
