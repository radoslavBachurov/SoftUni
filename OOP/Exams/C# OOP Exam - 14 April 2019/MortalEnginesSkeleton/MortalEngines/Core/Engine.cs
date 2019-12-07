using System;
using System.Linq;
using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(IWriter writer, IReader reader, ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = reader.ReadLine()) != "Quit")
            {
                try
                {
                    string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string result = commandInterpreter.Read(inputArr);
                    writer.Write(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }
            }
        }
    }
}
