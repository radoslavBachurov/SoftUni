using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine(IChampionshipController championshipController)
        {
            this.championshipController = championshipController;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
               .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string commandName = inputArgs[0];
                string[] commandArgs = inputArgs.Skip(1).ToArray();

                var method = typeof(ChampionshipController)
                   .GetMethod(commandName);

                List<object> requiredParams = new List<object>();

                foreach (var commandArg in commandArgs)
                {
                    if (int.TryParse(commandArg, out int parsedParam))
                    {
                        requiredParams.Add(parsedParam);

                        continue;
                    }

                    requiredParams.Add(commandArg);
                }

                string result = string.Empty;
                try
                {
                    result = (string)method.Invoke(this.championshipController, requiredParams.ToArray());
                }
                catch (Exception ex)
                {
                    result = ex.InnerException.Message;
                }

                Console.WriteLine(result);
            }

        }
    }
}
