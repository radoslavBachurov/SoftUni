using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_K_Numbers_seq
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenth = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] seq = new long[lenth];
            seq[0] = 1;
            long sum = 1;
            int counter = 0;

            Console.Write($"{seq[0]} ");

            for (int i = 1; i < lenth; i++)
            {
                seq[i] = sum;
                sum += seq[i];

                if (i <= k - 1)
                    Console.Write($"{seq[i]} ");
                else if (i > k - 1)
                {
                    sum -= seq[counter];
                    counter++;
                    Console.Write($"{seq[i]} ");
                }
            }

        }
    }
}
