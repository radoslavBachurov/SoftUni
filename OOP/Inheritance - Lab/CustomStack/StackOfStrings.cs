using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings :Stack<string>
    {
        public bool IsEmpty()
        {
            if(this.Count<=0)
            {
                return true;
            }
            return false;
        }

        public void AddRange(params string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                this.Push(input[i]);
            }
        }

    }
}
