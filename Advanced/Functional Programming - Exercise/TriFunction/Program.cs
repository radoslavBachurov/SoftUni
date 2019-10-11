using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> nameChek = (name, length) =>
              {
                  int sum = 0;
                  for (int i = 0; i < name.Length; i++)
                  {
                      sum += name[i];
                  }
                  if (sum >= length)
                  {
                      return true;
                  }

                  return false;
              };

            Func<List<string>, Func<string, int, bool>, int, string> MyfirstOrDefault = (listNames, nameCheck, length) =>
                  {
                      foreach (var name in listNames)
                      {
                          if (nameCheck(name, length))
                          {
                              return name;
                          }
                      }
                      return string.Empty;
                  };

            Console.WriteLine(MyfirstOrDefault(names, nameChek, number));
        }
    }
}
