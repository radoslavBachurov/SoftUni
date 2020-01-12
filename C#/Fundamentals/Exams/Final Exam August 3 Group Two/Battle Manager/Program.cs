using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Player> listOfPlayers = new Dictionary<string, Player>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Results")
            {
                string[] commandArr = command.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArr[0] == "Add")
                {
                    AddCommand(listOfPlayers, commandArr);
                }
                else if (commandArr[0] == "Atack")
                {
                    AtackCommand(listOfPlayers, commandArr);
                }
                else if (commandArr[0] == "Delete")
                {
                    DeleteCommand(listOfPlayers, commandArr);
                }
            }

            Printing(listOfPlayers);
        }

        private static void Printing(Dictionary<string, Player> listOfPlayers)
        {
            Console.WriteLine($"People count: {listOfPlayers.Count}");

            foreach (var player in listOfPlayers.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key} - {player.Value.Health} - {player.Value.Energy}");
            }
        }

        private static void DeleteCommand(Dictionary<string, Player> listOfPlayers, string[] commandArr)
        {
            string username = commandArr[1];

            if (username != "All")
            {
                if (listOfPlayers.ContainsKey(username))
                {
                    listOfPlayers.Remove(username);
                }
            }
            else
            {
                listOfPlayers.Clear();
            }
        }

        private static void AtackCommand(Dictionary<string, Player> listOfPlayers, string[] commandArr)
        {
            string atackerName = commandArr[1];
            string defenderName = commandArr[2];
            int damage = int.Parse(commandArr[3]);

            if (listOfPlayers.ContainsKey(atackerName) && listOfPlayers.ContainsKey(defenderName))
            {
                listOfPlayers[defenderName].Health -= damage;
                if (listOfPlayers[defenderName].Health <= 0)
                {
                    listOfPlayers.Remove(defenderName);
                    Console.WriteLine($"{defenderName} was disqualified!");
                }

                listOfPlayers[atackerName].Energy -= 1;
                if (listOfPlayers[atackerName].Energy == 0)
                {
                    listOfPlayers.Remove(atackerName);
                    Console.WriteLine($"{atackerName} was disqualified!");
                }

            }
        }

        private static void AddCommand(Dictionary<string, Player> listOfPlayers, string[] commandArr)
        {
            string name = commandArr[1];
            int health = int.Parse(commandArr[2]);
            int energy = int.Parse(commandArr[3]);

            if (!listOfPlayers.ContainsKey(name))
            {
                Player newPlayer = new Player();
                newPlayer.Health = health;
                newPlayer.Energy = energy;

                listOfPlayers.Add(name, newPlayer);
            }

            else
            {
                listOfPlayers[name].Health += health;
            }
        }
    }
    class Player
    {
        public Player()
        {
            Health = 0;
            Energy = 0;
        }
        public int Health { get; set; }
        public int Energy { get; set; }
    }
}
