using System;
using System.Collections.Generic;

namespace Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>
                { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            List<string> events = new List<string>
                { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            List<string> authors = new List<string>
                { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

            List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int numberMessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberMessages; i++)
            {
                Random rnd = new Random();
                int numberPhrases = rnd.Next(0, 6);

                Random rnd2 = new Random();
                int numberEvents = rnd2.Next(0, 6);

                Random rnd3 = new Random();
                int numberAuthors = rnd3.Next(1, 8);

                Random rnd4 = new Random();
                int numberCities = rnd4.Next(1, 5);

                Console.WriteLine($"{phrases[numberPhrases]} {events[numberEvents]} {authors[numberAuthors]} – {cities[numberCities]}.");
            }
        }
    }
}
