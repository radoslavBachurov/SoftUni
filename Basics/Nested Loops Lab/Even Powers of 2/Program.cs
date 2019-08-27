using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double limit = Math.Pow(2 , number);
            double evenPowers = 1;
            int power = 0;

            while (evenPowers <= limit)
            {
                if (power % 2 == 0)
                {
                    Console.WriteLine(evenPowers);
                }
                power++;
                evenPowers = Math.Pow( 2 ,power);
                
                    
               
            }
        }
    }
}
