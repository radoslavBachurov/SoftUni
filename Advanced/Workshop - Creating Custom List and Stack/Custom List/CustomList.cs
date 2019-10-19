using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_List
{
    public class CustomList
    {
        private int[] items;
        private const int initialCapacity = 2;

        public CustomList()
        {
            items = new int[initialCapacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public void Add(int number)
        {
            Resize();
            this.items[this.Count] = number;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int tempInt = this.items[index];
            ShiftToLeft(index);
            Shrink();
            return tempInt;
        }

        public void Insert(int index, int item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Resize();
            ShiftToRight(index, item);
            items[index] = item;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Count || secondIndex < 0 || secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int firstIndexTemp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = firstIndexTemp;
        }

        public int Find(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return element;
                }
            }

            return -1;
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                int temp = this.items[i];
                this.items[i] = this.items[Count - 1 - i];
                this.items[Count - 1 - i] = temp;
            }
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                newSB.Append($"{this.items[i]} , ");
            }

            return newSB.ToString().Trim(' ', ',');
        }

        private void ShiftToRight(int index, int item)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            items[this.Count - 1] = 0;
            this.Count--;
        }

        private void Shrink()
        {
            if (this.Count <= this.items.Length / 4)
            {
                int[] tempArray = new int[this.items.Length / 2];

                for (int i = 0; i < this.Count; i++)
                {
                    tempArray[i] = this.items[i];
                }
                this.items = tempArray;
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
