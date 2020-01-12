using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T>
    {
        private T input;
        public Box(T input)
        {
            this.input = input;
        }

        public override string ToString()
        {
            string toReturn = $"{input.GetType()}: {input}";
            return toReturn;
        }
    }
}
