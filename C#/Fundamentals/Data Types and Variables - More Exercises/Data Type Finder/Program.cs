using System;

namespace Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int integer;
            bool boolean;
            double floating;
            char character;

            while (type != "END")
            {
                if (int.TryParse(type, out integer))
                    Console.WriteLine($"{type} is integer type");
                else if (double.TryParse(type, out floating))
                    Console.WriteLine($"{type} is floating point type");
                else if (char.TryParse(type, out character))
                    Console.WriteLine($"{type} is character type");
                else if (bool.TryParse(type, out boolean))
                    Console.WriteLine($"{type} is boolean type");
                else
                    Console.WriteLine($"{type} is string type");
                type = Console.ReadLine();
            }


        }
    }
}
