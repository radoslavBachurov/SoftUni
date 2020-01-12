using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] twoDates = new string[2];

            for (int i = 0; i < 2; i++)
            {
                twoDates[i] = Console.ReadLine();
            }

            DateModifier newDates = new DateModifier(twoDates[0], twoDates[1]);
            Console.WriteLine(Math.Abs(Math.Round(newDates.Difference())));
        }
    }
}
