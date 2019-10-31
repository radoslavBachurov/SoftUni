using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        List<int> sortedStones;
        int[] input;
        public Lake(int[] input)
        {
            this.input = input;
            sortedStones = new List<int>();
            this.Sorting();
        }

        private void Sorting()
        {
            var odd = new List<int>();
            var even = new List<int>();
            int counter = 0;
            for (int i = 1; i <= this.input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(input[counter]);
                }
                else
                {
                    odd.Add(input[counter]);
                }
                counter++;
            }
            even.Reverse();

            sortedStones.AddRange(odd);
            sortedStones.AddRange(even);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LakeEnumerator(sortedStones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
