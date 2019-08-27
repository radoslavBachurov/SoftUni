using System;

namespace Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            if(char.IsLower(character))
                Console.WriteLine("lower-case");
            else
                Console.WriteLine("upper-case");
        }
    }
}
