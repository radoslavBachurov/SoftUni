using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string teststr = Console.ReadLine();
            int test = 0;
            var strInt = teststr.Split().First(x => int.TryParse(x, out test));
            Console.WriteLine(test);
            Console.WriteLine(strInt);
            
        }
    }
}
