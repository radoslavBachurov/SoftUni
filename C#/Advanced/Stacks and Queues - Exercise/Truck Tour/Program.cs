using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPumps = int.Parse(Console.ReadLine());
            Queue<Pump> pumpInfo = new Queue<Pump>();

            for (int i = 0; i < numberPumps; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                Pump newPump = new Pump(input[0], input[1], i);
                pumpInfo.Enqueue(newPump);
            }

            for (int i = 0; i < numberPumps; i++)
            {
                bool foundNumber = true;
                int totalOil = 0;
                int startIndex = pumpInfo.Peek().Index;

                for (int t = 0; t < numberPumps; t++)
                {
                    Pump currentPump = pumpInfo.Dequeue();
                    totalOil += currentPump.Oil - currentPump.Distance;
                    pumpInfo.Enqueue(currentPump);

                    if (totalOil < 0)
                    {
                        foundNumber = false;
                        break;
                    }
                }

                if (foundNumber)
                {
                    Console.WriteLine(startIndex);
                    return;
                }
            }
        }
    }
    class Pump
    {
        public Pump(int oil, int distance, int index)
        {
            Oil = oil;
            Distance = distance;
            Index = index;
        }
        public int Oil { get; set; }
        public int Distance { get; set; }
        public int Index { get; set; }
    }
}
