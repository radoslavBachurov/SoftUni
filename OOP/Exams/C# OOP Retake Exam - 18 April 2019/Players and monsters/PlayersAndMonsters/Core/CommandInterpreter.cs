using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IManagerController manageController;

        public CommandInterpreter(IManagerController manageController)
        {
            this.manageController = manageController;
        }

        public string Read(string[] args)
        {
            string command = args[0];
            string[] inputData = args.Skip(1).ToArray();

            var method = manageController.GetType().GetMethod(command);

            string result = (string)method.Invoke(manageController, inputData);
            return result;
        }

    }
}
