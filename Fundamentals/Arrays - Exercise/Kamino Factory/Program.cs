using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int seqLong = int.Parse(Console.ReadLine());

            int previousSubsequense = int.MinValue;
            int previousStartIndex = int.MaxValue;
            int previousSum = int.MinValue;
            int winStartIndex = int.MaxValue;
            int winSum = 0;
            string winDna = string.Empty;
            int winCounter = 1;
            int counterDna = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Clone them!")
                    break;

                int[] dnaSeq = command.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int lastDigit = 0;
                int counterSame = 1;
                int startIndex = 0;
                int max = int.MinValue;
                int sum = dnaSeq.Sum();
                bool replace = false;
                counterDna++;

                for (int i = 0; i < dnaSeq.Length; i++)
                {
                    if (i > 0)
                    {
                        if (dnaSeq[i] == lastDigit && dnaSeq[i] == 1)
                        {
                            counterSame++;

                            if (counterSame == 2)
                                startIndex = i - 1;

                            if (counterSame > max)
                                max = counterSame;
                        }
                        else
                            counterSame = 1;
                    }
                    lastDigit = dnaSeq[i];
                }
                if (max > previousSubsequense)
                {
                    winStartIndex = startIndex;
                    winSum = sum;
                    winDna = string.Join(" ", dnaSeq);
                    winCounter = counterDna;
                    replace = true;
                }
                else if (max == previousSubsequense)
                {
                    if (startIndex < previousStartIndex)
                    {
                        winStartIndex = startIndex;
                        winSum = sum;
                        winDna = string.Join(" ", dnaSeq);
                        winCounter = counterDna;
                        replace = true;
                    }
                    else if (startIndex == previousStartIndex)
                    {
                        if (sum > previousSum)
                        {
                            winStartIndex = startIndex;
                            winSum = sum;
                            winDna = string.Join(" ", dnaSeq);
                            winCounter = counterDna;
                            replace = true;
                        }
                    }

                }

                if (replace)
                {
                    previousSubsequense = max;
                    previousStartIndex = startIndex;
                    previousSum = sum;
                }

            }
            Console.WriteLine($"Best DNA sample {winCounter} with sum: {winSum}.");
            Console.WriteLine(winDna);
        }
    }
}
