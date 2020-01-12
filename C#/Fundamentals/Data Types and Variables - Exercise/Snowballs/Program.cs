using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSnowBalls = int.Parse(Console.ReadLine());
            BigInteger max = 0;
            int maxSnow = 0;
            int maxTime = 0;
            int maxQuality = 0;

            for (int i = 0; i < numberSnowBalls; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = (BigInteger.Pow((snowballSnow / snowballTime), snowballQuality));
                
                if (snowballValue > max)
                {
                    max = snowballValue;
                    maxSnow = snowballSnow;
                    maxTime = snowballTime;
                    maxQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{maxSnow} : {maxTime} = {max} ({maxQuality})");
            
        }
    }
}
