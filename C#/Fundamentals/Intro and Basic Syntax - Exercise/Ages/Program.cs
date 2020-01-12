using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string category = string.Empty;

            if (age >= 0 && age <= 2)
            {
                category = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                category = "child";
            }
            else if (age>= 14 && age <= 19)
            {
                category = "teenager";
            }
            else if (age >=20 && age <= 65)
            {
                category = "adult";
            }
            else
            {
                category = "elder";
            }

            Console.WriteLine(category);
        }
    }
}
