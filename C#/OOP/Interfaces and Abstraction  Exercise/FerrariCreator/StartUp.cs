using System;

namespace FerrariCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var newFerrari = new Ferrari(name);
            Console.WriteLine($"{newFerrari.Model}/{newFerrari.Break()}/{newFerrari.Gas()}/{newFerrari.Driver}");
           
        }
    }
}
