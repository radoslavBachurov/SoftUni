using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, LikesAndComments> listOfFollowers = new Dictionary<string, LikesAndComments>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] commandArr = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArr[0] == "New follower")
                {
                    ExecutingCommandNewFollower(listOfFollowers, commandArr);
                }
                else if (commandArr[0] == "Like")
                {
                    ExecutingCommandLike(listOfFollowers, commandArr);
                }
                else if (commandArr[0] == "Comment")
                {
                    ExecutingCommandComment(listOfFollowers, commandArr);
                }
                else if (commandArr[0] == "Blocked")
                {
                    ExecutingCommandBlocked(listOfFollowers, commandArr);
                }
            }

            Printing(listOfFollowers);
        }

        private static void Printing(Dictionary<string, LikesAndComments> listOfFollowers)
        {
            Console.WriteLine($"{listOfFollowers.Count} followers");
            foreach (var user in listOfFollowers.OrderByDescending(x => x.Value.Likes).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Comments + user.Value.Likes}");
            }
        }

        private static void ExecutingCommandBlocked(Dictionary<string, LikesAndComments> listOfFollowers, string[] commandArr)
        {
            string username = commandArr[1];
            if (listOfFollowers.ContainsKey(username))
            {
                listOfFollowers.Remove(username);
            }
            else
            {
                Console.WriteLine($"{username} doesn't exist.");
            }
        }

        private static void ExecutingCommandComment(Dictionary<string, LikesAndComments> listOfFollowers, string[] commandArr)
        {
            string username = commandArr[1];

            if (!listOfFollowers.ContainsKey(username))
            {
                LikesAndComments newList = new LikesAndComments();
                listOfFollowers.Add(username, newList);
            }

            listOfFollowers[username].Comments += 1;
        }

        private static void ExecutingCommandLike(Dictionary<string, LikesAndComments> listOfFollowers, string[] commandArr)
        {
            string username = commandArr[1];
            int count = int.Parse(commandArr[2]);

            if (!listOfFollowers.ContainsKey(username))
            {
                LikesAndComments newList = new LikesAndComments();
                listOfFollowers.Add(username, newList);
            }

            listOfFollowers[username].Likes += count;
        }

        private static void ExecutingCommandNewFollower(Dictionary<string, LikesAndComments> listOfFollowers, string[] commandArr)
        {
            string username = commandArr[1];

            if (!listOfFollowers.ContainsKey(username))
            {
                LikesAndComments newList = new LikesAndComments();
                listOfFollowers.Add(username, newList);
            }
        }
    }
    class LikesAndComments
    {
        public LikesAndComments()
        {
            Likes = 0;
            Comments = 0;
        }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}
