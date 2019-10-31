using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class CustomStack : IEnumerable<int>
    {
        List<int> myStack;

        public CustomStack()
        {
            myStack = new List<int>();
        }

        public void Push(params int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                myStack.Add(input[i]);
            }
        }

        public string Pop()
        {
            if (myStack.Any())
            {
                int lastElement = myStack[myStack.Count - 1];
                myStack.RemoveAt(myStack.Count - 1);
                return lastElement.ToString();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MyStackENumerator(myStack);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
