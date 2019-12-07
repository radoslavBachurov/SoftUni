using System.Collections.Generic;
using System.Linq;
using MortalEngines.Core.Contracts;
using MortalEngines.Common;

namespace MortalEngines.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IMachinesManager managerController;
        private readonly List<string> commands;

        public CommandInterpreter(IMachinesManager managerController)
        {
            this.managerController = managerController;
        }

        public string Read(string[] inputArgs)
        {
            string commandName = CommandConverter.Convert(inputArgs[0]);
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            var method = typeof(MachinesManager)
               .GetMethod(commandName);

            List<object> requiredParams = new List<object>();

            foreach (var commandArg in commandArgs)
            {
                if (double.TryParse(commandArg, out double parsedParam))
                {
                    requiredParams.Add(parsedParam);

                    continue;
                }

                requiredParams.Add(commandArg);
            }

            string result = (string)method.Invoke(this.managerController, requiredParams.ToArray());

            return result;
        }
    }
}
