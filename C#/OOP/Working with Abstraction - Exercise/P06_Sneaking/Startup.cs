using System;

namespace P06_Sneaking
{
    public class Startup
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            Engine newEngine = new Engine(rows);
            newEngine.Run();
        }
    }
}
