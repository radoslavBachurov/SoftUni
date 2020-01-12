using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenth = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] seq = new int[lenth];
            seq[0] = 1;
            int sum = 1;
            int counter = 0;

            Console.WriteLine(seq[0]);

            for (int i = 1; i < lenth; i++)
            {
                seq[i] = sum;
                sum += seq[i];

                if (i <= k - 1)
                    Console.WriteLine(seq[i]);
                else if (i > k - 1)
                {
                    
                    sum -= seq[counter];
                    counter++;
                    Console.WriteLine(seq[i]);
                }
            }

        }
    }
}
