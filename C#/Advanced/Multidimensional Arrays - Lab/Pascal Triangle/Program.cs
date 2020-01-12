using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            long[][] jaggedArr = new long[count][];

            int numberColls = 1;

            for (int i = 0; i < count; i++)
            {
                jaggedArr[i] = new long[i + 1];
                jaggedArr[i][0] = 1;
                jaggedArr[i][numberColls - 1] = 1;

                if (i > 1)
                {
                    for (int t = 1; t < numberColls - 1; t++)
                    {
                        jaggedArr[i][t] = jaggedArr[i - 1][t - 1] + jaggedArr[i - 1][t];
                    }
                }
                numberColls++;
            }

            foreach (var item in jaggedArr)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}
