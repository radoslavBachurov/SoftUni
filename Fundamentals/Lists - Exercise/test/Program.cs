using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
namespace List2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cordinates = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int index = int.Parse(Console.ReadLine());
            int removedSum = 0;
            int currentNumber;
            while (cordinates.Count > 0)
            {
                if (index >= cordinates.Count)
                {
                    currentNumber = cordinates[cordinates.Count - 1];
                    removedSum += cordinates[cordinates.Count - 1];
                    cordinates.RemoveAt(cordinates.Count - 1);
                    cordinates.Add(cordinates[0]);
                    
                   
                }
                else if (index < 0)
                {
                    currentNumber = cordinates[0];
                    removedSum += cordinates[0];
                    cordinates.RemoveAt(0);
                    cordinates.Insert(0, cordinates[cordinates.Count - 1]);
                    
                    
                }
                else
                {
                    removedSum += cordinates[index];
                    currentNumber = cordinates[index];
                    cordinates.RemoveAt(index);
                }
                if (cordinates.Count <= 0)
                {
                    break;
                }
                for (int i = 0; i < cordinates.Count; i++)
                {
                    int checkNumber = cordinates[i];
                    if (currentNumber < checkNumber)
                    {
                        cordinates[i] -= currentNumber;
                    }
                    else if(currentNumber>=checkNumber)
                    {
                        cordinates[i] += currentNumber;
                    }
                }
                index = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(removedSum);
        }
    }
}