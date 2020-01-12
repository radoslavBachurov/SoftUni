using System;

namespace Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num < 3)
                NumSmallerThanThree(num);
            else
                TribonaciSeq(num);

        }

        private static void NumSmallerThanThree(int num)
        {
            if (num == 0)
                return;
            else if(num==1)
                Console.WriteLine(1);
            else if(num==2)
                Console.WriteLine("1 1");
        }

        private static void TribonaciSeq(int num)
        {
            int[] arr = new int[3];
            arr[0] = 1;
            arr[1] = 1;
            arr[2] = 2;
            Console.Write(string.Join(" ", arr));


            for (int i = 3; i < num; i++)
            {
                int[] newarr = new int[arr.Length + 1];

                for (int t = 0; t < arr.Length; t++)
                {
                    newarr[t] = arr[t];
                }

                newarr[i] = arr[i - 3] + arr[i - 2] + arr[i - 1];
                Console.Write($" {newarr[i]}");
                arr = newarr;
            }
        }
    }
}
