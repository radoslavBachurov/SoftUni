using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                string output = string.Empty;
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        output = controller.AddAstronaut(input[1], input[2]);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string[] items = input.Skip(2).ToArray(); ;
                        output = controller.AddPlanet(input[1],items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        output = controller.RetireAstronaut(input[1]);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        output = controller.ExplorePlanet(input[1]);
                    }
                    else if(input[0] == "Report")
                    {
                        output = controller.Report();
                    }

                    writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
