using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ReceivingInputCommand(arr);
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void ReceivingInputCommand(int[] arr)
        {
            while (true)
            {
                string commandInput = Console.ReadLine();

                if (commandInput == "end")
                    break;

                if (commandInput.Contains("exchange"))
                {
                    int number = 0;
                    var exchangeIndex = commandInput.Split().First(x => int.TryParse(x, out number));
                    ExecutingExchangeIndexCommand(arr, number);
                }

                else if (commandInput.Contains("max"))
                    ExecutingMaxEvenOddCommand(arr, commandInput);

                else if (commandInput.Contains("min"))
                    ExecutingMinEvenOddCommand(arr, commandInput);

                else if (commandInput.Contains("first") || commandInput.Contains("last"))
                {
                    int countEvenOdd = int.Parse(Regex.Match(commandInput, @"\d+").Value);

                    if (countEvenOdd > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    else if (commandInput.Contains("first"))
                        ExecutingFirstEvenOddCommand(arr, commandInput, countEvenOdd);

                    else if (commandInput.Contains("last"))
                        ExecutingLastEvenOddCommand(arr, commandInput, countEvenOdd);
                }
            }
        }

        private static void ExecutingLastEvenOddCommand(int[] arr, string commandInput, int countEvenOdd)
        {
            //EVEN
            if (commandInput.Contains("even"))
            {
                int countEvenNumbers = countEvenOdd - 1;
                string[] evenArrLast = new string[countEvenOdd];

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        evenArrLast[countEvenNumbers] = arr[i].ToString();
                        countEvenNumbers--;
                    }
                    if ((countEvenNumbers < 0 || i == 0) && countEvenNumbers != countEvenOdd - 1)
                    {
                        evenArrLast = evenArrLast.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        Console.WriteLine($"[{ string.Join(", ", evenArrLast)}]");
                        return;
                    }
                }
                if (countEvenNumbers == countEvenOdd - 1)
                    Console.WriteLine("[]");
            }
            //ODD
            else if (commandInput.Contains("odd"))
            {
                int countOddNumbers = countEvenOdd - 1;
                string[] oddArrLast = new string[countEvenOdd];

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 != 0)
                    {
                        oddArrLast[countOddNumbers] = arr[i].ToString();
                        countOddNumbers--;
                    }
                    if ((countOddNumbers < 0 || i == 0) && countOddNumbers != countEvenOdd - 1)
                    {
                        oddArrLast = oddArrLast.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        Console.WriteLine($"[{ string.Join(", ", oddArrLast)}]");
                        return;
                    }
                }
                if (countOddNumbers == countEvenOdd - 1)
                    Console.WriteLine("[]");
            }
        }
        private static void ExecutingFirstEvenOddCommand(int[] arr, string commandInput, int countEvenOdd)
        {
            //EVEN
            if (commandInput.Contains("even"))
            {
                int countEvenNumbers = 0;
                string[] evenArr = new string[countEvenOdd];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        evenArr[countEvenNumbers] = arr[i].ToString();
                        countEvenNumbers++;
                    }
                    if ((countEvenNumbers == evenArr.Length || i == arr.Length - 1) && countEvenNumbers != 0)
                    {
                        evenArr = evenArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        Console.WriteLine($"[{ string.Join(", ", evenArr)}]");
                        return;
                    }
                }
                if (countEvenNumbers == 0)
                    Console.WriteLine("[]");
            }
            //ODD
            else if (commandInput.Contains("odd"))
            {
                int countOddNumbers = 0;
                string[] oddArr = new string[countEvenOdd];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        oddArr[countOddNumbers] = arr[i].ToString();
                        countOddNumbers++;
                    }
                    if ((countOddNumbers == oddArr.Length || i == arr.Length - 1) && countOddNumbers != 0)
                    {
                        oddArr = oddArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        Console.WriteLine($"[{ string.Join(", ", oddArr)}]");
                        return;
                    }
                }
                if (countOddNumbers == 0)
                    Console.WriteLine("[]");
            }


        }
        private static void ExecutingMinEvenOddCommand(int[] arr, string commandInput)
        {
            int min = int.MaxValue;
            //EVEN
            if (commandInput.Contains("even"))
            {
                int evenMinIndex = 0;

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (arr[i] < min)
                        {
                            evenMinIndex = i;
                            min = arr[i];
                        }
                    }
                }

                if (min != int.MaxValue)
                    Console.WriteLine(evenMinIndex);
                else
                    Console.WriteLine("No matches");
            }
            //ODD
            else if (commandInput.Contains("odd"))
            {
                int oddMinIndex = 0;

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 != 0)
                    {
                        if (arr[i] < min)
                        {
                            oddMinIndex = i;
                            min = arr[i];
                        }
                    }
                }

                if (min != int.MaxValue)
                    Console.WriteLine(oddMinIndex);
                else
                    Console.WriteLine("No matches");
            }
            min = int.MaxValue;
        }
        private static void ExecutingMaxEvenOddCommand(int[] arr, string commandInput)
        {
            int max = int.MinValue;
            //EVEN
            if (commandInput.Contains("even"))
            {
                int evenMaxIndex = 0;

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (arr[i] > max)
                        {
                            evenMaxIndex = i;
                            max = arr[i];
                        }
                    }
                }

                if (max != int.MinValue)
                    Console.WriteLine(evenMaxIndex);
                else
                    Console.WriteLine("No matches");
            }
            //ODD
            else if (commandInput.Contains("odd"))
            {
                int oddMaxIndex = 0;

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 != 0)
                    {
                        if (arr[i] > max)
                        {
                            oddMaxIndex = i;
                            max = arr[i];
                        }
                    }
                }

                if (max != int.MinValue)
                    Console.WriteLine(oddMaxIndex);
                else
                    Console.WriteLine("No matches");
            }
            max = int.MinValue;
        }
        private static void ExecutingExchangeIndexCommand(int[] arr, int exchangeIndex)
        {
            if (exchangeIndex < 0 || exchangeIndex >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= exchangeIndex; i++)
            {
                int firstNumber = arr[0];
                for (int t = 0; t < arr.Length - 1; t++)
                {
                    arr[t] = arr[t + 1];
                }
                arr[arr.Length - 1] = firstNumber;
            }
        }
    }
}

