using System;
using System.Linq;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var newCitizen = new Citizen(inputArr[0], inputArr[1],int.Parse(inputArr[2]));

                IPerson nameOnly = newCitizen;
                IResident namePlus = newCitizen;
                Console.WriteLine(nameOnly.GetName());
                Console.WriteLine(namePlus.GetName());
            }
        }
    }
}
