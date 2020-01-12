using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();

                string result = this.commandInterpreter.Read(args);

                Console.WriteLine(result);
            }
            
        }
    }
}
