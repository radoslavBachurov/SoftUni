using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayerEggs = int.Parse(Console.ReadLine());
            int secondPlayerEggs = int.Parse(Console.ReadLine());

            while (firstPlayerEggs != 0 && secondPlayerEggs != 0)
            {
                string command = Console.ReadLine();
                if(command== "End of battle")
                {
                    break;
                }
                switch (command)
                {
                    case "one":
                        secondPlayerEggs -= 1;
                        break;
                    case "two":
                        firstPlayerEggs -= 1;
                        break;
                }
            }
            if (firstPlayerEggs == 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayerEggs} eggs left.");
            }
            else if (secondPlayerEggs == 0)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayerEggs} eggs left.");
            }
            else
            {
                Console.WriteLine($"Player one has {firstPlayerEggs} eggs left.");
                Console.WriteLine($"Player two has {secondPlayerEggs} eggs left.");
            }
        }


    }
}
