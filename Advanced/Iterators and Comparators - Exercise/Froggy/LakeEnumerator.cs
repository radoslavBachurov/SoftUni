using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class LakeEnumerator : IEnumerator<int>
    {
        private readonly List<int> sortedStones;
        private int index;
        public LakeEnumerator(List<int> input)
        {
            this.sortedStones = input;
            this.Reset();
        }

        public int Current
        {
            get
            {
                return sortedStones[index];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;
            if(index<sortedStones.Count)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
