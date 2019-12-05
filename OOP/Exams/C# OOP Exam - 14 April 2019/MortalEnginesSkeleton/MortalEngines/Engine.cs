using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MortalEngines.Core.Contracts;
using MortalEngines.Core;

namespace MortalEngines
{

    public class Engine : IEngine
    {
        private MachinesManager manager;
        private Writer writer;

        public Engine()
        {
            manager = new MachinesManager();
            writer = new Writer();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Quit")
            {
                try
                {
                    string toWrite = string.Empty;

                    string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (inputArr[0] == "HirePilot")
                    {
                        toWrite = manager.HirePilot(inputArr[1]);
                    }
                    else if (inputArr[0] == "PilotReport")
                    {
                        toWrite = manager.PilotReport(inputArr[1]);
                    }
                    else if (inputArr[0] == "Attack")
                    {
                        toWrite = manager.AttackMachines(inputArr[1], inputArr[2]);
                    }
                    else if (inputArr[0] == "Engage")
                    {
                        toWrite = manager.EngageMachine(inputArr[1], inputArr[2]);
                    }
                    else if (inputArr[0] == "DefenseMode")
                    {
                        toWrite = manager.ToggleFighterAggressiveMode(inputArr[1]);
                    }
                    else if (inputArr[0] == "AggressiveMode")
                    {
                        toWrite = manager.ToggleFighterAggressiveMode(inputArr[1]);
                    }
                    else if (inputArr[0] == "MachineReport")
                    {
                        toWrite = manager.MachineReport(inputArr[1]);
                    }
                    else if (inputArr[0] == "ManufactureFighter")
                    {
                        string name = inputArr[1];
                        double atack = double.Parse(inputArr[2]);
                        double defence = double.Parse(inputArr[3]);
                        toWrite = manager.ManufactureFighter(name, atack, defence);
                    }
                    else if (inputArr[0] == "ManufactureTank")
                    {
                        string name = inputArr[1];
                        double atack = double.Parse(inputArr[2]);
                        double defence = double.Parse(inputArr[3]);
                        toWrite = manager.ManufactureTank(name, atack, defence);
                    }

                    writer.Write(toWrite);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }
            }
        }
    }
}
