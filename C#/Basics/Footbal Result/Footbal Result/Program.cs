using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footbal_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            int win = 0;
            int loss = 0;
            int even = 0;
            for (int i = 0; i < 3; i++)
            {
                string result = Console.ReadLine();
                char firstNumber = result[0];
                char secondNumber = result[2];

                if (firstNumber > secondNumber)
                {
                    win++;
                }
                else if (firstNumber < secondNumber)
                {
                    loss++;
                }
                else if (firstNumber == secondNumber)
                {
                    even++;
                }
            }

            Console.WriteLine($"Team won {win} games.");
            Console.WriteLine($"Team lost {loss} games.");
            Console.WriteLine($"Drawn games: {even}");
            
        }




    }
}

