using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int symbolOne = 1; symbolOne <= n; symbolOne++)
            {
                for (int symboltwo = 1; symboltwo <= n; symboltwo++)
                {
                    for (int symbolThree = 'a'; symbolThree < 'a' + l; symbolThree++)
                    {
                        for (int symbolFour = 'a'; symbolFour < 'a' + l; symbolFour++)
                        {
                            for (int symbolFive = 1; symbolFive <= n; symbolFive++)

                                if (symbolFive > symbolOne && symbolFive > symboltwo)
                                {
                                    Console.Write($"{symbolOne}{symboltwo}{(char)symbolThree}{(char)symbolFour}{symbolFive} ");

                                }


                        }

                    }
                }
            }
        }
    }
}
