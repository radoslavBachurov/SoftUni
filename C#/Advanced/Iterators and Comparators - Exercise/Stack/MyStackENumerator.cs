using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStackENumerator : IEnumerator<int>
    {
        private readonly List<int> myStack;
        private int index;
        public MyStackENumerator(List<int> stack)
        {
            this.myStack = stack;
            this.Reset();
        }
        public int Current
        {
            get
            {
                return myStack[this.index];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.index--;
            if (this.index >= 0)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.index = this.myStack.Count;
        }

    }
}




