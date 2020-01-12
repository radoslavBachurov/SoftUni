using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Dictionary<string, Messages> listOfUsers = new Dictionary<string, Messages>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArr = input.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = inputArr[0];

                if (command == "Add")
                {
                    AddUsers(listOfUsers, inputArr);
                }
                else if (command == "Message")
                {
                    MessageUsers(capacity, listOfUsers, inputArr);
                }
                else if (command == "Empty")
                {
                    EmptyUsers(listOfUsers, inputArr);
                }
            }

            Printing(listOfUsers);

        }

        private static void Printing(Dictionary<string, Messages> listOfUsers)
        {
            Console.WriteLine($"Users count: {listOfUsers.Count}");

            foreach (var user in listOfUsers.OrderByDescending(x => x.Value.Received).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value.Total}");
            }
        }

        private static void EmptyUsers(Dictionary<string, Messages> listOfUsers, string[] inputArr)
        {
            string username = inputArr[1];

            if (username != "All")
            {
                if (listOfUsers.ContainsKey(username))
                {
                    listOfUsers.Remove(username);
                }

            }
            else
            {
                listOfUsers.Clear();
            }
        }

        private static void MessageUsers(int capacity, Dictionary<string, Messages> listOfUsers, string[] inputArr)
        {
            string sender = inputArr[1];
            string receiver = inputArr[2];

            if (listOfUsers.ContainsKey(sender) && listOfUsers.ContainsKey(receiver))
            {
                listOfUsers[sender].Send += 1;
                listOfUsers[sender].Total += 1;

                if (listOfUsers[sender].Total >= capacity)
                {
                    listOfUsers.Remove(sender);
                    Console.WriteLine($"{sender} reached the capacity!");
                }

                listOfUsers[receiver].Received += 1;
                listOfUsers[receiver].Total += 1;

                if (listOfUsers[receiver].Total >= capacity)
                {
                    listOfUsers.Remove(receiver);
                    Console.WriteLine($"{receiver} reached the capacity!");
                }


            }
        }

        private static void AddUsers(Dictionary<string, Messages> listOfUsers, string[] inputArr)
        {
            string username = inputArr[1];
            int send = int.Parse(inputArr[2]);
            int received = int.Parse(inputArr[3]);

            if (!listOfUsers.ContainsKey(username))
            {
                Messages newUser = new Messages();
                newUser.Send = send;
                newUser.Received = received;
                newUser.Total = send + received;

                listOfUsers.Add(username, newUser);
            }
        }
    }
    class Messages
    {
        public Messages()
        {
            Received = 0;
            Send = 0;
            Total = 0;
        }
        public int Received { get; set; }
        public int Send { get; set; }
        public int Total { get; set; }
    }
}
