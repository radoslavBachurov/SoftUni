using System;

namespace DistanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double stepLenghtCm = double.Parse(Console.ReadLine());
            int distanceToTravelMetres = int.Parse(Console.ReadLine());

            double distanceTraveled = 0;
            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                {
                    double fifthStepLenght = stepLenghtCm;
                    fifthStepLenght *= 0.7;
                    distanceTraveled += fifthStepLenght;
                    continue;
                }
                else
                {
                    distanceTraveled += stepLenghtCm;
                }
            }

            double distantPercent = distanceTraveled / distanceToTravelMetres;
            
            Console.WriteLine($"You travelled {distantPercent:f2}% of the distance!");
        }
    }
}
