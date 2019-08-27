using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyInStock = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double pricePerSaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double totalSabers = (Math.Ceiling(students + (students * 0.1))) * pricePerSaber;
            double totalRobes = students * pricePerRobe;
            double totalBelts = (students - (students / 6))*pricePerBelt;
            double totalPrice = totalBelts + totalRobes + totalSabers;

            if(totalPrice<=moneyInStock)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice-moneyInStock):f2}lv more.");
            }



        }
    }
}
