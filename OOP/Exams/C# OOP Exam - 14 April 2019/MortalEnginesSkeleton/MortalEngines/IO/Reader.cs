using System;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
