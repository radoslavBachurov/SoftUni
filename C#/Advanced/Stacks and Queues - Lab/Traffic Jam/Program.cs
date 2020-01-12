using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightPass = int.Parse(Console.ReadLine());
            Queue<string> newQueue = new Queue<string>();

            int carsPassed = 0;
            string incomingCar = string.Empty;

            while ((incomingCar = Console.ReadLine()) != "end")
            {
                if (incomingCar == "green")
                {
                    for (int i = 0; i < greenLightPass; i++)
                    {
                        if (newQueue.Count > 0)
                        {
                            Console.WriteLine($"{newQueue.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                }
                else
                {
                    newQueue.Enqueue(incomingCar);
                }
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
