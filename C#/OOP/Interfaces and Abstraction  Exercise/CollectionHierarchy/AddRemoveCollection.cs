using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        public AddRemoveCollection() : base()
        {
        }

        public override int Add(T item)
        {

            T toAdd = default(T);

            for (int i = 0; i <= this.index; i++)
            {
                if (i == 0)
                {
                    toAdd = this.internalArray[i];
                    this.internalArray[i] = item;
                }
                else
                {
                    T current = internalArray[i];
                    this.internalArray[i] = toAdd;
                    toAdd = current;
                }
            }

            this.index++;
            return 0;
        }

        public virtual T Remove()
        {
            T toReturn = default(T);
            if (this.index > 0)
            {
                toReturn = this.internalArray[index - 1];
                this.internalArray[index - 1] = default(T);
                this.index--;

            }
            return toReturn;
        }
    }
}
