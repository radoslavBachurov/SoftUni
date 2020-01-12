using System;
using System.Collections.Generic;
using System.Linq;

namespace Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> warriors = new Stack<int>();

            int numberWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int plate = 0;
            for (int i = 1; i <= numberWaves; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                int[] newWave = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int t = 0; t < newWave.Length; t++)
                {
                    warriors.Push(newWave[t]);
                }

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (warriors.Any() && plates.Any())
                {
                    int warrior = warriors.Peek();
                    if (plate == 0)
                    {
                        plate = plates.Peek();
                    }

                    if (warrior == plate)
                    {
                        warriors.Pop();
                        plates.Dequeue();
                        plate = 0;
                    }
                    else if (warrior > plate)
                    {
                        warrior -= plate;
                        warriors.Pop();
                        warriors.Push(warrior);
                        plates.Dequeue();
                        plate = 0;
                    }
                    else if (plate > warrior)
                    {
                        warriors.Pop();
                        plate -= warrior;
                    }
                }
            }

            if (plate > 0)
            {
                plates.Dequeue();
                plates = new Queue<int>(plates.Reverse());
                plates.Enqueue(plate);
                plates = new Queue<int>(plates.Reverse());
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}