using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWagons = int.Parse(Console.ReadLine());
            int[] people = new int[numberWagons];

            for (int i = 0; i < numberWagons; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", people));
            int sum = people.Sum();
            Console.WriteLine(sum);


        }
    }
}
