using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            bool typeworkday = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday";
            bool typeweekend = day == "Saturday" || day == "Sunday";
            double banana = 0;
            double apple = 0;
            double orange = 0;
            double grapefruit = 0;
            double kiwi = 0;
            double pineapple = 0;
            double grapes = 0;
            double fruitprice = 0;

            if (typeworkday)
            {
                switch (fruit)
                {
                    case "banana":
                        banana = 2.50;
                        fruitprice = quantity * banana;

                        break;
                    case "apple":
                        apple = 1.20;
                        fruitprice = quantity * apple;
                        break;
                    case "orange":
                        orange = 0.85;
                        fruitprice = quantity * orange;
                        break;
                    case "grapefruit":
                        grapefruit = 1.45;
                        fruitprice = quantity * grapefruit;
                        break;
                    case "kiwi":
                        kiwi = 2.70;

                        fruitprice = quantity * kiwi;
                        break;
                    case "pineapple":
                        pineapple = 5.50;
                        fruitprice = quantity * pineapple;
                        break;
                    case "grapes":
                        grapes = 3.85;
                        fruitprice = quantity * grapes;
                        break;
                    default:
                        
                        break;
                }


            }

            
            else if (typeweekend)
            {

                switch (fruit)
                {
                    case "banana":
                        banana = 2.70;
                        fruitprice = quantity * banana;
                        break;
                    case "apple":
                        apple = 1.25;
                        fruitprice = quantity * apple;
                        break;
                    case "orange":
                        orange = 0.90;
                        fruitprice = quantity * orange;
                        break;
                    case "grapefruit":
                        grapefruit = 1.60;
                        fruitprice = quantity * grapefruit;
                        break;
                    case "kiwi":
                        kiwi = 3.00;
                        fruitprice = quantity * kiwi;
                        break;
                    case "pineapple":
                        pineapple = 5.60;
                        fruitprice = quantity * pineapple;
                        break;
                    case "grapes":
                        grapes = 4.20;
                        fruitprice = quantity * grapes;
                        break;
                    default:
                        
                        break;
                }


            }

            
            

            if (fruitprice>0)
            {
                Console.WriteLine($"{fruitprice:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }












        }




    }
}

