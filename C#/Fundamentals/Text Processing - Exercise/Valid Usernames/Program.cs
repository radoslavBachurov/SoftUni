using System;
using System.Linq;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ").ToArray();


            foreach (var username in words)
            {
                bool trueUser = true;

                if (username.Length < 3 || username.Length > 16)
                {
                    trueUser = false;
                }

                for (int i = 0; i < username.Length; i++)
                {
                    if ((!char.IsLetterOrDigit(username[i])) && username[i] != '-' && username[i] != '_')
                    {
                        trueUser = false;
                    }

                }

                if (trueUser)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}
