using System;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrSeq = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] mainseq = new int[(arrSeq.Length / 4) * 2];

            for (int i = 0; i < mainseq.Length; i++)
            {
                mainseq[i] = arrSeq[(arrSeq.Length - (int)(mainseq.Length*1.5))+ i];
            }

            int[] secSeq = new int[mainseq.Length];

            int counter = 1;
            for (int i = 0; i < mainseq.Length; i++)
            {
                secSeq[i] = arrSeq[(arrSeq.Length - (int)(mainseq.Length * 1.5))-counter];
                counter++;

                if (arrSeq.Length - (int)(mainseq.Length * 1.5) - counter < 0)
                    counter = (-arrSeq.Length + (arrSeq.Length - (int)(mainseq.Length * 1.5))+1);
                
            }

            for (int i = 0; i < secSeq.Length; i++)
            {
                Console.Write($"{mainseq[i]+secSeq[i]} ");
            }
        }
    }
}
