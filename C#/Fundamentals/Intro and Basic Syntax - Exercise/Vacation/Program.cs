using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (day)
            {
                case "Friday":
                    switch (typeGroup)
                    {
                        case "Students":
                            price = 8.45;
                            if (numberPeople >= 30)
                            {
                                price = price * 0.85;
                            }
                            break;
                        case "Business":
                            price = 10.9;
                            if (numberPeople >= 100)
                            {
                                numberPeople -= 10;
                            }
                            break;
                        case "Regular":
                            price = 15;
                            if (numberPeople >= 10 && numberPeople <= 20)
                            {
                                price = price * 0.95;
                            }
                            break;
                    }
                    break;
                case "Saturday":
                    switch (typeGroup)
                    {
                        case "Students":
                            price = 9.8;
                            if (numberPeople >= 30)
                            {
                                price = price * 0.85;
                            }
                            break;
                        case "Business":
                            price = 15.6;
                            if (numberPeople >= 100)
                            {
                                numberPeople -= 10;
                            }
                            break;
                        case "Regular":
                            price = 20;
                            if (numberPeople >= 10 && numberPeople <= 20)
                            {
                                price = price * 0.95;
                            }
                            break;
                    }
                    break;

                case "Sunday":
                    switch (typeGroup)
                    {
                        case "Students":
                            price = 10.46;
                            if (numberPeople >= 30)
                            {
                                price = price * 0.85;
                            }
                            break;
                        case "Business":
                            price = 16;
                            if (numberPeople >= 100)
                            {
                                numberPeople -= 10;
                            }
                            break;
                        case "Regular":
                            price = 22.5;
                            if (numberPeople >= 10 && numberPeople <= 20)
                            {
                                price = price * 0.95;
                            }
                            break;
                    }
                    break;

            }
            
            Console.WriteLine($"Total price: {(numberPeople*price):f2}");

        }
    }
}
