using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());
            int[] row1 = new int[1];
            row1[0] = 1;
            int[] row2 = new int[1];

            for (int i = 1; i <= numberRows; i++)
            {
                Console.WriteLine(string.Join(" ", row1));

                row2 = row1;
                row1 = new int[row2.Length + 1];

                for (int t = 0; t < row1.Length; t++)
                {
                    if (t == row1.Length - 1)
                        row1[t] = row2[t - 1] + 0;

                    else if (row1.Length == 2)
                    {
                        row1[0] = 1;
                        row1[1] = 1;
                    }

                    else if (t > 0)
                    {
                       
                        row1[t] = row2[t] + row2[t - 1];
                    }
                }

            }
        }
    }
}
