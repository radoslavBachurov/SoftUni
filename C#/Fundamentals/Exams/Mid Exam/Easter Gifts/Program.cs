using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] commandArr = command.Split().ToArray();

                if (commandArr.Contains("OutOfStock"))
                {
                    for (int i = 0; i < gifts.Count; i++)
                    {
                        if (gifts[i] == commandArr[1])
                        {
                            gifts.RemoveAt(i);
                            gifts.Insert(i, "None");
                        }
                    }

                }
                else if (commandArr.Contains("Required"))
                {
                    int index = int.Parse(commandArr[2]);

                    if (index >= 0 && index < gifts.Count)
                    {
                        gifts.RemoveAt(index);
                        gifts.Insert(index, commandArr[1]);
                    }
                }
                else if (commandArr.Contains("JustInCase"))
                {
                    gifts.RemoveAt(gifts.Count - 1);
                    gifts.Add(commandArr[1]);
                }
            }


            foreach (var gift in gifts)
            {
                if (gift != "None")
                {
                    Console.Write(gift + " ");
                }
            }
        }
    }
}
