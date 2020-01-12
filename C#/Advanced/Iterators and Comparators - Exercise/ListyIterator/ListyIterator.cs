using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> List;
        private int index;

        public ListyIterator(T[] input)
        {
            this.List = input.ToList();
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index < List.Count - 1)
            {
                return true;
            }
            return false;
        }

        public string Print()
        {
            if (this.List.Any())
            {
                return $"{this.List[index]}";
            }
            else
            {
                return "Invalid Operation!";
            }
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ",this.List));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.List)
            {
                yield return item;
            }     
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
