using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Shortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> people = new List<IBuyer>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(input.Length == 3)
                {
                    people.Add(new Rebel(input[0], input[1], input[2]));
                }
                else
                {
                    people.Add(new Citizen(input[0], input[1], input[2],input[3]));
                }
            }

            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                if(people.Any(x=>x.Name==command))
                {
                    IBuyer toAddFood = people.Find(x => x.Name == command);
                    toAddFood.BuyFood();
                }
            }

            int allFood = people.Sum(x => x.Food);
            Console.WriteLine(allFood);
        }
    }
}
