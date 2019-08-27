using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyprice = double.Parse(Console.ReadLine());
            double bira = double.Parse(Console.ReadLine());
            double vino = double.Parse(Console.ReadLine());
            double rakiq = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());
            double rakiqpracepl = whiskeyprice / 2;
            double winepriceperl = rakiqpracepl-(rakiqpracepl * 0.4);
            double birapricepl = rakiqpracepl -(rakiqpracepl* 0.8);
            double price = bira * birapricepl + vino * winepriceperl + rakiq * rakiqpracepl + whiskey * whiskeyprice;
            Console.WriteLine($"{price:f2}");
        }
    }
}
