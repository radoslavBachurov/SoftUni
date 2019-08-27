using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (char i = 'a'; i < 'a'+number; i++)
            {
                for (char t = 'a'; t < 'a'+number; t++)
                {
                    for (char s = 'a'; s < 'a'+number; s++)
                    {
                        Console.WriteLine($"{i}{t}{s}");
                    }
                }
            }
        }
    }
}
