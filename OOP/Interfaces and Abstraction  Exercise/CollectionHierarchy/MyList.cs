using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public MyList() : base()
        {
        }

        public int Used => this.index;

        public override T Remove()
        {
            T toReturn = this.internalArray[0];

            for (int i = 1; i < this.index; i++)
            {
                this.internalArray[i - 1] = this.internalArray[i];
            }

            index--;
            return toReturn;
        }
    }
}
