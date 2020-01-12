using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minuteOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minuteOfArrival = int.Parse(Console.ReadLine());

            int timeOfExam = (hourOfExam * 60) + minuteOfExam;
            int timeOfArrival = (hourOfArrival * 60) + minuteOfArrival;

            if (timeOfExam >= timeOfArrival)
            {
                int timeBeforeExam = timeOfExam - timeOfArrival;
                int hoursBeforeExam = Math.Abs(timeBeforeExam / 60);
                double minBeforeExam = Math.Abs(timeBeforeExam - (hoursBeforeExam * 60));
                if (timeBeforeExam > 30)
                {
                    Console.WriteLine("Early");
                    
                    if (timeBeforeExam < 60)
                    {
                        Console.WriteLine($"{minBeforeExam} minutes before the start");
                    }
                    else if (timeBeforeExam >= 60)
                    {
                        if (minBeforeExam >= 0 && minBeforeExam <= 9)
                        {
                            Console.WriteLine($"{hoursBeforeExam}:0{minBeforeExam} hours before the start");
                        }
                        else if (minBeforeExam > 9)
                        {
                            Console.WriteLine($"{hoursBeforeExam}:{minBeforeExam} hours before the start");
                        }
                    }
                }
                if (timeBeforeExam <= 30)

                {
                    Console.WriteLine("On time");
                    if (timeBeforeExam != 0)
                    Console.WriteLine($"{minBeforeExam} minutes before the start");
                }
            }
            else 
            {
                int timeLate = timeOfArrival - timeOfExam;
                int hoursAfterExam = Math.Abs(timeLate / 60);
                double minAfterExam = Math.Abs(timeLate - (hoursAfterExam * 60));
                Console.WriteLine("Late");
                if (timeLate >= 1 && timeLate <= 9)
                {
                    Console.WriteLine($"{minAfterExam} minutes after the start");
                }
                else if (timeLate > 9 && timeLate < 60)
                {
                    Console.WriteLine($"{minAfterExam} minutes after the start");
                }
                else if (timeLate >= 60)
                {
                    if (minAfterExam >= 0 && minAfterExam <= 9)
                    {
                        Console.WriteLine($"{hoursAfterExam}:0{minAfterExam} hours after the start");
                    }
                    else if (timeLate > 9)
                    {
                        Console.WriteLine($"{hoursAfterExam}:{minAfterExam} hours after the start");
                    }

                }



            }


        }
    }
}
