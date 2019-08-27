using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var userPointsList = new Dictionary<string, int>();
            var nameSumbissions = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArr = input.Split("-").ToArray();
                
                if(inputArr[1]=="banned")
                {
                    BannedCommand(userPointsList, nameSumbissions, inputArr);
                    continue;
                }

                StoringData(userPointsList, nameSumbissions, inputArr);
            }

            Printing(userPointsList, nameSumbissions);
        }

        private static void Printing(Dictionary<string, int> userPointsList, Dictionary<string, int> nameSumbissions)
        {
            Console.WriteLine("Results:");

            foreach (var user in userPointsList.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in nameSumbissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }

        private static void BannedCommand(Dictionary<string, int> userPointsList, Dictionary<string, int> nameSumbissions, string[] inputArr)
        {
            string username = inputArr[0];

            if(userPointsList.ContainsKey(username))
            {
                userPointsList.Remove(username);
            }
        }

        private static void StoringData(Dictionary<string, int> userPointsList, Dictionary<string, int> nameSumbissions, string[] inputArr)
        {
            string username = inputArr[0];
            string language = inputArr[1];
            int points = int.Parse(inputArr[2]);

            if (!userPointsList.ContainsKey(username))
            {
                userPointsList.Add(username, points);
            }
            else
            {
                if (userPointsList[username] < points)
                {
                    userPointsList[username] = points;
                }
            }

            if (!nameSumbissions.ContainsKey(language))
            {
                nameSumbissions.Add(language, 1);
            }
            else
                nameSumbissions[language]++;
        }
    }

}
