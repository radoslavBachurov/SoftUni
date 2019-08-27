using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < roomsPerFloor; i++)
            {
                Console.Write($"L{floors}{i} ");
            }

            Console.WriteLine();
            floors -= 1;

            for (int i = floors; i > 0; i--)
            {
                if (floors % 2 == 0)
                {
                    for (int j = 0; j < roomsPerFloor; j++)
                    {
                        Console.Write($"O{floors}{j} ");
                        
                    }
                    Console.WriteLine();
                }

                else if (floors% 2 != 0)
                {
                    for (int s = 0; s < roomsPerFloor; s++)
                    {
                        Console.Write($"A{floors}{s} ");
                        
                    }
                    Console.WriteLine();
                }
                floors--;
            }
        }
    }
}
