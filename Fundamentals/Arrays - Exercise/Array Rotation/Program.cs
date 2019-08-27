using System;
using System.Linq;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ").ToArray();
            int rotationNumber = int.Parse(Console.ReadLine());
            string[] firstRotationSeq = new string[arr.Length];
            int counter = 0;


            if (rotationNumber < arr.Length)
            {
                int rotationVar = rotationNumber;
                while (true)
                {
                    
                    firstRotationSeq[counter] = arr[rotationVar];
                    counter++;
                    rotationVar++;
                    if (rotationVar == arr.Length)
                    {
                        rotationVar = 0;
                    }
                    if (rotationVar == rotationNumber)
                        break;
                }
            }
            if (rotationNumber >= arr.Length)
            {
                rotationNumber -= arr.Length;
                int rotationVar = rotationNumber;

                while (true)
                {
                    firstRotationSeq[counter] = arr[rotationVar];
                    counter++;
                    rotationVar++; 
                    if (rotationVar == arr.Length)
                    {
                        rotationVar = 0;
                    }
                    if (rotationVar == rotationNumber)
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",firstRotationSeq));
        }
    }
}
