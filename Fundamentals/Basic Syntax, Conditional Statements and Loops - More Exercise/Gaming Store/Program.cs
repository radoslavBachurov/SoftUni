using System;

namespace Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal currentballance = decimal.Parse(Console.ReadLine());
            decimal startBallance = currentballance;

            while (true)
            {
                string game = Console.ReadLine();
                bool notFound = false;
                decimal lastBallance = currentballance;

                switch (game)
                {
                    case "Game Time":
                        Console.WriteLine($"Total spent: ${startBallance - currentballance:f2}. Remaining: ${currentballance:f2}");
                        notFound = true;
                        return;
                        
                    case "OutFall 4":
                        currentballance -= 39.99m;
                        break;
                    case "CS: OG":
                        currentballance -= 15.99m;
                        break;
                    case "Zplinter Zell":
                        currentballance -= 19.99m;
                        break;
                    case "Honored 2":
                        currentballance -= 59.99m;
                        break;
                    case "RoverWatch":
                        currentballance -= 29.99m;
                        break;
                    case "RoverWatch Origins Edition":
                        currentballance -= 39.99m;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        notFound = true;
                        continue;
                }
                if (currentballance >= 0 && notFound == false)
                {
                    Console.WriteLine($"Bought {game}");
                    if (currentballance == 0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
                }
                else if (currentballance < 0)
                {
                    Console.WriteLine("Too Expensive");
                    currentballance = lastBallance;
                }

            }
        }
    }
}
