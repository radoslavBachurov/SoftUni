using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte people = byte.Parse(Console.ReadLine());
            byte capacity = byte.Parse(Console.ReadLine());

            int numberCourses = people / capacity;
            if (people % capacity == 0)
                Console.WriteLine(people / capacity);
            else if (people % capacity != 0)
                Console.WriteLine((people / capacity) + 1);

        }
    }
}
