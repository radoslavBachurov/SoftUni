using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> listOfInput;
        public Box(List<T> input)
        {
            listOfInput = input;
        }

        public int Comparrison(T numberToCompare)
        {
            int count = 0;

            for (int i = 0; i < listOfInput.Count; i++)
            {
                int compareResult = numberToCompare.CompareTo(listOfInput[i]);
                if(compareResult == -1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
