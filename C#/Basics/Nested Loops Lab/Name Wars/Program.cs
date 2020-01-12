using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            string maxName = "Empty";
            string name = "Empty";

            while (name != "STOP")
            {
                name = Console.ReadLine();
                int sumSymbol = 0;
                if (name != "STOP")
                {
                    int textLenth = name.Length;
                    for (int i = 0; i < textLenth; i++)
                    {
                        int symbol = name[i];
                        sumSymbol += symbol;

                    }
                    if (sumSymbol > max)
                    {
                        max = sumSymbol;
                        maxName = name;
                    }

                }
            }
            Console.WriteLine($"Winner is {maxName} - {max}!");
        }
    }
}

