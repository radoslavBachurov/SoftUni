using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsSum = 0;
            while (stepsSum < 10000)
            {
                string stepsPerDayOrHome = Console.ReadLine();
                
                if (stepsPerDayOrHome == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    stepsSum += stepsToHome;
                    if (stepsSum >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                    else
                    {
                        int stepsleft = 10000 - stepsSum;
                        Console.WriteLine($"{stepsleft} more steps to reach goal.");
                        break;
                    }

                }

                else
                {
                    int stepsPerDay = int.Parse(stepsPerDayOrHome);
                    stepsSum += stepsPerDay;
                    if (stepsSum >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                    }
                }
            }




        }


    }
}