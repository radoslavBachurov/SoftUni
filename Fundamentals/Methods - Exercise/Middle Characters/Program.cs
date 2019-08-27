using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            PrintMiddleCharacter(str);
        }

        private static void PrintMiddleCharacter(string str)
        {
            if (str.Length % 2 == 0)
            {
                int middle = str.Length / 2;
                Console.WriteLine($"{str[middle-1]}{str[middle]}");
            }
            else if(str.Length %2 != 0)
            {
                int middle = str.Length / 2;
                Console.WriteLine($"{str[middle]}");
            }
        }
    }
}
