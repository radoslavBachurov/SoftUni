using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songQueue = new Queue<string>(Console.ReadLine()
                .Split(new string[] { ", ", "\t" }, StringSplitOptions.RemoveEmptyEntries));

            while (songQueue.Count > 0)
            {
                string command = Console.ReadLine();
                    

                if (command == "Play" && songQueue.Count > 0)
                {
                    songQueue.Dequeue();
                }
                
                else if (command == "Show" && songQueue.Count > 0)
                {
                    Console.WriteLine(string.Join(", ",songQueue));
                }

                else
                {
                    string[] commandArr = command
                    .Split("Add ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                    if (!songQueue.Contains(commandArr[0]))
                    {
                        songQueue.Enqueue(commandArr[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{commandArr[0]} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
            return;

        }
    }
}
