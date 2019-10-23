using System;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                var newBox = new Box<string>(input);
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}
