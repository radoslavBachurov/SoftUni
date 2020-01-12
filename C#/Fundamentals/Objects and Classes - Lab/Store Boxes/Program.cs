using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Box> orderedList = new List<Box>();
            List<Box> boxes = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArr = input.Split().ToArray();
                SortingItems(inputArr, boxes);
            }

            orderedList = boxes.OrderByDescending(x => x.BoxPrice).ToList();
            Printing(orderedList);
        }

        private static void Printing(List<Box> orderedList)
        {
            foreach (Box item in orderedList)
            {
                Console.WriteLine($"{item.SerialNumber}");
                Console.WriteLine($"-- {item.Item} - ${item.Price:f2}: {item.Quantity}");
                Console.WriteLine($"-- ${item.BoxPrice:f2}");
            }
        }

        private static void SortingItems(string[] inputArr, List<Box> boxes)
        {
            Box singleBox = new Box();


            singleBox.SerialNumber = inputArr[0];
            singleBox.Item = inputArr[1];
            singleBox.Quantity = int.Parse(inputArr[2]);
            singleBox.Price = decimal.Parse(inputArr[3]);
            singleBox.BoxPrice = int.Parse(inputArr[2]) * decimal.Parse(inputArr[3]);
            boxes.Add(singleBox);
        }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal BoxPrice { get; set; }
        public decimal Price { get; set; }
    }

}
