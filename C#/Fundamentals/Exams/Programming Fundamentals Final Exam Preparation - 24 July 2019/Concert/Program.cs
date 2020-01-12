using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> bandAndMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsPlayTime = new Dictionary<string, int>();
            int sumTime = 0;

            while ((input = Console.ReadLine()) != "start of concert")
            {
                string[] inputArr =  Regex.Split(input,@"; |, ").ToArray();

                if (inputArr[0] == "Add")
                {
                    AddingBandAndMembers(inputArr, bandAndMembers);
                }
                else if (inputArr[0] == "Play")
                {
                    BandsPlayTime(inputArr, bandsPlayTime);
                    sumTime += int.Parse(inputArr[2]);
                }
            }

            string bandMembersToPrint = Console.ReadLine();

            Printing(bandsPlayTime, bandAndMembers, bandMembersToPrint, sumTime);
        }

        private static void Printing(Dictionary<string, int> bandsPlayTime, Dictionary<string, List<string>> bandAndMembers, string bandMembersToPrint, int sumTime)
        {
            Console.WriteLine($"Total time: {sumTime}");

            foreach (var item in bandsPlayTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }


            Console.WriteLine($"{bandMembersToPrint}");

            foreach (var item in bandAndMembers[bandMembersToPrint])
            {
                Console.WriteLine($"=> {item}");
            }
        }

        private static void BandsPlayTime(string[] inputArr, Dictionary<string, int> bandsPlayTime)
        {
            string bandName = inputArr[1];
            int playtime = int.Parse(inputArr[2]);
           

            if (!bandsPlayTime.ContainsKey(bandName))
            {
                bandsPlayTime.Add(bandName, playtime);
                
            }
            else
            {
                bandsPlayTime[bandName] += playtime;
               
            }
            
        }

        private static void AddingBandAndMembers(string[] inputArr, Dictionary<string, List<string>> bandAndMembers)
        {
            string bandName = inputArr[1];

            if (!bandAndMembers.ContainsKey(bandName))
            {
                bandAndMembers.Add(bandName, new List<string>());
            }

            for (int i = 2; i < inputArr.Length; i++)
            {
                if (!bandAndMembers[bandName].Contains(inputArr[i]))
                {
                    bandAndMembers[bandName].Add(inputArr[i]);
                }
            }

        }
    }
}
