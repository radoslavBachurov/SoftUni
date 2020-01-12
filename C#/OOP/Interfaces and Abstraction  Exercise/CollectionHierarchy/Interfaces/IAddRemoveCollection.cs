using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
