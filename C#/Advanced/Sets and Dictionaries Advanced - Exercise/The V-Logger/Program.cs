using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfVloggers = new Dictionary<string, Vlogger>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArr[1] == "joined")
                {
                    VloggersJoining(listOfVloggers, inputArr);
                }
                else if (inputArr[1] == "followed")
                {
                    VloggersFollowing(listOfVloggers, inputArr);
                }
            }

            Printing(listOfVloggers);
        }

        private static void Printing(Dictionary<string, Vlogger> listOfVloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {listOfVloggers.Count} vloggers in its logs.");

            int numberVlogger = 1;
            foreach (var vlogger in listOfVloggers.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{numberVlogger}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                numberVlogger++;

                if (numberVlogger == 2)
                {
                    foreach (var person in vlogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {person}");
                    }
                }
            }
        }

        private static void VloggersFollowing(Dictionary<string, Vlogger> listOfVloggers, string[] inputArr)
        {
            string vloggerFollowing = inputArr[0];
            string vloggerFollowed = inputArr[2];

            if (listOfVloggers.ContainsKey(vloggerFollowed) &&
                listOfVloggers.ContainsKey(vloggerFollowing) &&
                vloggerFollowing != vloggerFollowed)
            {
                listOfVloggers[vloggerFollowing].Following.Add(vloggerFollowed);
                listOfVloggers[vloggerFollowed].Followers.Add(vloggerFollowing);
            }
        }

        private static void VloggersJoining(Dictionary<string, Vlogger> listOfVloggers, string[] inputArr)
        {
            string vlogger = inputArr[0];

            if (!listOfVloggers.ContainsKey(vlogger))
            {
                listOfVloggers.Add(vlogger, new Vlogger());
            }
        }
    }
    class Vlogger
    {
        public Vlogger()
        {
            Followers = new SortedSet<string>();
            Following = new HashSet<string>();
        }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
