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

        public Lake(int[] input)
        {
            sortedStones = input.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < sortedStones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return sortedStones[i];
                }
            }

            for (int i = sortedStones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return sortedStones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
