using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletCount = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int i = 1;
                for (i = 1; i <= gunBarrelSize; i++)
                {
                    if (bullets.Count > 0 && locks.Count > 0)
                    {
                        int bullet = bullets.Pop();
                        int currentLock = locks.Peek();
                        bulletCount++;

                        if (bullet <= currentLock)
                        {
                            Console.WriteLine("Bang!");
                            locks.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Ping!");
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (bullets.Count > 0 && i==gunBarrelSize+1)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - (bulletCount * bulletPrice)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
