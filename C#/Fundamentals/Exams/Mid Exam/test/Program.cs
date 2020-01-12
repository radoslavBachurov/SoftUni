using System;
using System.Numerics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                .Split()
                .ToList();
            string cmd = Console.ReadLine();

            while (cmd != "No Money")
            {
                string[] tokens = cmd.Split();
                switch (tokens[0])
                {
                    case "OutOfStock":
                        string giftName = tokens[1];
                        if (gifts.Contains(giftName))
                        {
                            for (int i = 0; i < gifts.Count; i++)
                            {
                                if (gifts[i] == tokens[1])
                                {
                                    gifts.RemoveAt(i);
                                    gifts.Insert(i, "None");
                                }
                            }
                        }
                        break;
                    case "Required":
                        
                        int index = int.Parse(tokens[2]);

                        if (index >= 0 && index < gifts.Count)
                        {
                            gifts.RemoveAt(index);
                            gifts.Insert(index, tokens[1]);
                        }
                        break;
                    case "JustInCase":
                        string replacementGift = tokens[1];
                        gifts.RemoveAt(gifts.Count-1);
                        gifts.Add(replacementGift);
                        break;
                    default:
                        break;
                }
                
                
                cmd = Console.ReadLine();
            }
            for (int i = 0; i < gifts.Count; i++)
            {
                if (gifts.Contains("None"))
                {
                    int index = gifts.IndexOf("None");
                    gifts.RemoveAt(index);
                }
            }
            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}