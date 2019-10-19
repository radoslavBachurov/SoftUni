using System;
using System.Collections.Generic;
using System.Text;

namespace CutomStack
{
    class MyStack
    {
        private const int initialCapacity = 4;
        private int[] items;

        public MyStack()
        {
            items = new int[initialCapacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count <= 0)
            {
                throw new Exception("Stack is Empty");
            }

            int last = this.items[Count - 1];
            this.Count--;
            return last;
        }

        public int Peek()
        {
            if (this.Count <= 0)
            {
                throw new Exception("Stack is Empty");
            }

            int last = this.items[Count - 1];
            return last;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }

            int[] tempArray = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                tempArray[i] = items[i];
            }

            items = tempArray;
        }
    }
}
