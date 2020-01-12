using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    public interface IMyList<T> : IAddRemoveCollection<T>
    {
         int Used { get; }
    }
}
