using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T, T2, T3>
    {
        public Threeuple(T first, T2 second, T3 third)
        {
            this.item1 = first;
            this.item2 = second;
            this.item3 = third;
        }

        public T item1 { get; set; }
        public T2 item2 { get; set; }
        public T3 item3 { get; set; }

        public override string ToString()
        {
            string toReturn = $"{this.item1} -> {this.item2} -> {this.item3}";
            return toReturn;
        }
    }
}
