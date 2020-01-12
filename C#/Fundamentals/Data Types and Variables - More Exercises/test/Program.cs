using System;

namespace _6.Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            bool balance = true;
            bool open = false;

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    if (!open) open = true;
                    else balance = false;
                }
                if (input == ")")
                {
                    if (open) open = false;
                    else balance = false;
                }
            }
            if (balance && !open) Console.WriteLine("BALANCED");
            else Console.WriteLine("UNBALANCED");
        }
    }
}

