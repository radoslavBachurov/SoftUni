using System;

namespace Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = new int[int.Parse(Console.ReadLine())];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }
            Array.Reverse(digits);
            Console.WriteLine(string.Join(" ",digits));


        }
    }
}
