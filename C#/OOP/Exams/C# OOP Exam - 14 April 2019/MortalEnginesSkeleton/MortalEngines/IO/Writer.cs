using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class Writer : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
