using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine newEngine = new Engine();
            newEngine.Run();
        }
    }
}
