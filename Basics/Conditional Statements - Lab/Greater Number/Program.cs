using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberone = int.Parse(Console.ReadLine());
            int numbertwo = int.Parse(Console.ReadLine());
            if (numberone>=numbertwo)
            {
                Console.WriteLine(numberone);
            }
            else if(numbertwo>=numberone)
            {
                Console.WriteLine(numbertwo);
            }


        }
    }
}
