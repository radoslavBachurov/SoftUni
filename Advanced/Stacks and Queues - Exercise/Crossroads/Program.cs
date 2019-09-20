using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> carQueue = new Queue<string>();

            string input = string.Empty;
            int carPassed = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int greenLight = greenLightDuration;

                    if (carQueue.Count > 0)
                    {
                        int count = carQueue.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (greenLight > 0
                                && greenLight + freeWindowDuration - carQueue.Peek().Length >= 0)
                            {
                                greenLight -= carQueue.Dequeue().Length;
                                carPassed++;
                            }
                            else
                            {
                                if (greenLight <= 0)
                                {
                                    break;
                                }
                                else
                                {
                                    string lastCar = carQueue.Peek();
                                    int index = greenLight + freeWindowDuration;
                                    char hitPoint = lastCar[index];
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{lastCar} was hit at {hitPoint}.");
                                    return;
                                }
                            }

                        }
                    }

                }
                else
                {
                    carQueue.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carPassed} total cars passed the crossroads.");
        }
    }
}
