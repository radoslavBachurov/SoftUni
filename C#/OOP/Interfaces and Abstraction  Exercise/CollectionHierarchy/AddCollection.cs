using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class AddCollection<T> : IAddCollection<T>
    {
        protected T[] internalArray;
        protected int index;

        public AddCollection()
        {
            internalArray = new T[100];
            index = 0;
        }

        public virtual int Add(T item)
        {
            this.internalArray[index] = item;
            int currentIndex = index;
            index++;
            return currentIndex;
        }
    }


}
