using _1._Chronometer.Interfaces;
using System;
using System.Linq;

namespace _1._Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            IChronometer myChronometer = new Chronometer();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exit")
            {

                string output = "";

                switch (command)
                {
                    case "start":
                        myChronometer.Start();
                        break;
                    case "stop":
                        myChronometer.Stop();
                        break;
                    case "lap":
                        output = myChronometer.Lap();
                        break;
                    case "laps":
                        string result = myChronometer.Laps.Count == 0 ? "No Laps" : "\r\n" + string.Join("\r\n", myChronometer.Laps.Select((lap, index) => $"{index}. {lap}"));
                        output = $"Laps: {result}";
                        ;
                        break;
                    case "time":
                        output = myChronometer.GetTime;
                        break;
                    case "reset":
                        myChronometer.Reset();
                        break;
                    default:
                        break;
                }

                if (output != "")
                {
                    Console.WriteLine(output);
                }
            }
        }
    }
}
