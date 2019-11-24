using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsArr = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string command = (argsArr[0] + "command").ToLower();

            string[] commandArgs = args.Split(" ").Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == command);
                
            if (type == null)
            {
                throw new ArgumentException("Invalid Command");
            }

            ICommand commandToExecute = Activator.CreateInstance(type) as ICommand;

            string result = commandToExecute.Execute(commandArgs);

            return result;
        }
    }
}
