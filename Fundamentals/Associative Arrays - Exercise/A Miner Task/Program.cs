using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource;
            int quantity;
            var listOfResources = new Dictionary<string, int>();

            while ((resource=Console.ReadLine())!="stop")
            {
                quantity = int.Parse(Console.ReadLine());

                if(listOfResources.ContainsKey(resource))
                {
                    listOfResources[resource] += quantity;
                }

                else
                {
                    listOfResources.Add(resource, quantity);
                }
            }

            foreach (var item in listOfResources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
