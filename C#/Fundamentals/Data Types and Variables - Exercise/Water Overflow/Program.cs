using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int tankCapacity = 255;
            int numberLines = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numberLines; i++)
            {
                int litresFlow = int.Parse(Console.ReadLine());
                tankCapacity -= litresFlow;

                if (tankCapacity < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                    tankCapacity += litresFlow;
                }
                else
                {
                    continue;
                }

            }
            Console.WriteLine(255 - tankCapacity);
        }
    }
}
