using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfPlayersPosition = new Dictionary<string, List<playerInfo>>();
            var totalSkillPlayers = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Season end")
            {
                string[] inputArr = Regex.Split(input, @"\s->\s|\svs\s").ToArray();

                if (inputArr.Length == 3)
                {
                    AddingPlayers(listOfPlayersPosition, totalSkillPlayers, inputArr);
                }
                else
                {
                    Duel(listOfPlayersPosition, totalSkillPlayers, inputArr);
                }
            }

            Printing(listOfPlayersPosition, totalSkillPlayers);
        }

        private static void Printing(Dictionary<string, List<playerInfo>> listOfPlayersPosition, Dictionary<string, int> totalSkillPlayers)
        {
            foreach (var player in totalSkillPlayers.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");

                foreach (var person in listOfPlayersPosition[player.Key].OrderByDescending(x => x.Skill).ThenBy(x => x.Position))
                {
                    Console.WriteLine($"- {person.Position} <::> {person.Skill}");
                }
            }
        }

        private static void Duel(Dictionary<string, List<playerInfo>> listOfPlayersPosition, Dictionary<string, int> totalSkillPlayers, string[] inputArr)
        {
            string firstPlayer = inputArr[0];
            string secondPlayer = inputArr[1];

            if (listOfPlayersPosition.ContainsKey(firstPlayer) && listOfPlayersPosition.ContainsKey(secondPlayer))
            {
                bool duel = false;

                foreach (var position in listOfPlayersPosition[firstPlayer])
                {
                    if (listOfPlayersPosition[secondPlayer].Any(x => x.Position == position.Position))
                    {
                        duel = true;
                    }
                }

                if (duel)
                {
                    if (totalSkillPlayers[firstPlayer] > totalSkillPlayers[secondPlayer])
                    {
                        totalSkillPlayers.Remove(secondPlayer);
                        listOfPlayersPosition.Remove(secondPlayer);
                    }
                    else if (totalSkillPlayers[secondPlayer] > totalSkillPlayers[firstPlayer])
                    {
                        totalSkillPlayers.Remove(firstPlayer);
                        listOfPlayersPosition.Remove(firstPlayer);
                    }
                }
            }
        }

        private static void AddingPlayers(Dictionary<string, List<playerInfo>> listOfPlayersPosition, Dictionary<string, int> totalSkillPlayers, string[] inputArr)
        {
            string player = inputArr[0];
            string position = inputArr[1];
            int skill = int.Parse(inputArr[2]);

            if (!listOfPlayersPosition.ContainsKey(player))
            {
                playerInfo newPlayer = new playerInfo(position, skill);
                listOfPlayersPosition.Add(player, new List<playerInfo>());
                listOfPlayersPosition[player].Add(newPlayer);
                totalSkillPlayers.Add(player, skill);
            }
            else
            {
                if (listOfPlayersPosition[player].Any(x => x.Position == position))
                {
                    playerInfo infoToChange = listOfPlayersPosition[player].Find(x => x.Position == position);

                    if (infoToChange.Skill < skill)
                    {
                        int difference = skill - infoToChange.Skill;
                        infoToChange.Skill = skill;
                        totalSkillPlayers[player] += difference;
                    }
                }
                else
                {
                    playerInfo newPlayer = new playerInfo(position, skill);
                    listOfPlayersPosition[player].Add(newPlayer);
                    totalSkillPlayers[player] += skill;
                }
            }
        }
    }
    class playerInfo
    {
        public playerInfo(string position, int skill)
        {
            Position = position;
            Skill = skill;
        }
        public string Position { get; set; }
        public int Skill { get; set; }
    }
}
