using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSteps = int.Parse(Console.ReadLine());
            int numberDancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double stepsPerDay = numberSteps / days;
            double stepsPerDancerPerDay = stepsPerDay / numberDancers;
            double stepsperdaypercent = Math.Ceiling(stepsPerDay * (100.0 / numberSteps));
            double percentPerDancer = stepsperdaypercent / numberDancers; 

            if(stepsperdaypercent <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentPerDancer:f2}%.");

            }
            else if (stepsperdaypercent > 13)
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {percentPerDancer:f2}% steps to be learned per day."
);
            }
        }
    }
}
