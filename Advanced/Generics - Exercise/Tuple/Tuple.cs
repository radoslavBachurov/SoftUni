using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T, T2>
    {
        public Tuple(T first, T2 second)
        {
            this.item1 = first;
            this.item2 = second;
        }

        public T item1 { get; set; }
        public T2 item2 { get; set; }

        public override string ToString()
        {
            string toReturn = $"{this.item1} -> {this.item2}";
            return toReturn;
        }
    }
}
