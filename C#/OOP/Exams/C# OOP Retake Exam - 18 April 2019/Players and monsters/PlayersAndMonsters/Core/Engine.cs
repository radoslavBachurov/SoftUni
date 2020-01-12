using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = reader.ReadLine()) != "Exit")
            {
                string[] args = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    string result = commandInterpreter.Read(args);
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}
