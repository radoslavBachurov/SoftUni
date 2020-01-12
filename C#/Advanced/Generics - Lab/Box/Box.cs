using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> repository;
        public Box()
        {
            repository = new List<T>();
        }

        public int Count => repository.Count;

        public void Add(T element)
        {
            repository.Add(element);
        }

        public T Remove()
        {
            T element = repository[repository.Count - 1];
            repository.RemoveAt(repository.Count - 1);
            return element;
        }


    }
}
