using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reversedPass = string.Empty;
            int lenght = username.Length;
            int counter = 0;

            for (int i = lenght - 1; i >= 0; i--)
            {
                reversedPass += username[i];
            }

            while (counter < 4)
            {
                string enterPass = Console.ReadLine();
                counter++;
                if (enterPass == reversedPass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (enterPass != reversedPass && counter < 4)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                    Console.WriteLine($"User {username} blocked!");

            }


        }
    }
}
