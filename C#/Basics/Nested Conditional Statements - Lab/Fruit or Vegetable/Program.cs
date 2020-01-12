using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string food = Console.ReadLine();
            bool fruit = food == "banana" || food == "banana" || food == "apple" || food == "kiwi" || food == "cherry" || food == "lemon" || food == "grapes";
            bool vegetable = food == "tomato" || food == "cucumber" || food == "pepper" || food == "carrot";
            string answer = "answer";
            if (fruit)
            {
                answer = "fruit";
            }
            else if (vegetable)
            {
                answer = "vegetable";
            }
            else
            {
                answer = "unknown";
            }
            Console.WriteLine($"{answer}");
                



        }
    }
}
