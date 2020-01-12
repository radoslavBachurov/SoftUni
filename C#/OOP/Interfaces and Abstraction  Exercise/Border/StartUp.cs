using System;
using System.Collections.Generic;
using System.Linq;

namespace Border //Problem 6.Birthday Celebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ListOfBirthDates = new List<IBirthdate>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split().ToArray();

                if (inputArr[0] == "Pet")
                {
                    ListOfBirthDates.Add(new Pet(inputArr[1], inputArr[2]));
                }
                else if (inputArr[0] == "Citizen")
                {
                    ListOfBirthDates.Add(new Citizen(inputArr[1], inputArr[2], inputArr[3], inputArr[4]));
                }
            }

            string date = Console.ReadLine();

            foreach (var enterer in ListOfBirthDates.Where(x => x.BirthDay.EndsWith(date)))
            {
                Console.WriteLine(enterer.BirthDay);
            }
        }

    }
}
