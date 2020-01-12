using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Interfaces;
using MilitaryElite.Soldiers;

namespace MilitaryElite
{
    public class Engine
    {
        List<ISoldier> soldiersList;

        public Engine()
        {
            soldiersList = new List<ISoldier>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] inputArr = input
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    switch (inputArr[0])
                    {
                        case "Private":
                            PrivateCreator(inputArr);
                            break;
                        case "LieutenantGeneral":
                            LieutenantGeneralCreator(inputArr);
                            break;
                        case "Engineer":
                            EngineerCreator(inputArr);
                            break;
                        case "Commando":
                            CommandoCreator(inputArr);
                            break;
                        case "Spy":
                            SpyCreator(inputArr);
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }

            foreach (var soldier in soldiersList)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private void SpyCreator(string[] inputArr)
        {
            string id = inputArr[1];
            string firstName = inputArr[2];
            string lastName = inputArr[3];
            int codeNumber = int.Parse(inputArr[4]);
            var spy = new Spy(id, firstName, lastName, codeNumber);

            soldiersList.Add(spy);
        }

        private void CommandoCreator(string[] inputArr)
        {
            string id = inputArr[1];
            string firstName = inputArr[2];
            string lastName = inputArr[3];
            decimal salary = decimal.Parse(inputArr[4]);
            string corps = inputArr[5];

            var commando = new Commando(id, firstName, lastName, corps, salary);

            for (int i = 6; i < inputArr.Length; i += 2)
            {
                commando.AddMissions(inputArr[i], inputArr[i + 1]);
            }

            soldiersList.Add(commando);
        }

        private void EngineerCreator(string[] inputArr)
        {
            string id = inputArr[1];
            string firstName = inputArr[2];
            string lastName = inputArr[3];
            decimal salary = decimal.Parse(inputArr[4]);
            string corps = inputArr[5];

            Engineer engineer = new Engineer(id, firstName, lastName, corps, salary);

            for (int i = 6; i < inputArr.Length; i += 2)
            {
                engineer.AddPart(inputArr[i], double.Parse(inputArr[i + 1]));
            }
            soldiersList.Add(engineer);
        }

        private void LieutenantGeneralCreator(string[] inputArr)
        {
            string id = inputArr[1];
            string firstName = inputArr[2];
            string lastName = inputArr[3];
            decimal salary = decimal.Parse(inputArr[4]);
            var newLieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < inputArr.Length; i++)
            {
                if (soldiersList.Any(x => x.Id == inputArr[i]))
                {
                    Private toAdd = (Private)soldiersList.FirstOrDefault(x => x.Id == inputArr[i]);
                    newLieutenantGeneral.AddPrivate(toAdd);
                }
            }

            soldiersList.Add(newLieutenantGeneral);
        }

        private void PrivateCreator(string[] inputArr)
        {
            string id = inputArr[1];
            string firstName = inputArr[2];
            string lastName = inputArr[3];
            decimal salary = decimal.Parse(inputArr[4]);
            soldiersList.Add(new Private(id, firstName, lastName, salary));
        }
    }
}
