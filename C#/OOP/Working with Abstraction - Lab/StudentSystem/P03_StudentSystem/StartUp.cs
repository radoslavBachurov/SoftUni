namespace P03_StudentSystem
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            var newEngine =  new Engine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exit")
            {
                string[] commandArr = command.Split();
                newEngine.Action(commandArr);
            }
        }
    }
}
