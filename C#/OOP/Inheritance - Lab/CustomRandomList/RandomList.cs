using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList 
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random newRandom = new Random();
            int index = newRandom.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
