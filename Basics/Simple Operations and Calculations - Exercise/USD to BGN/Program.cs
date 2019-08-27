using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double usdtobgn = usd * 1.79549;
            double roundedbgn = Math.Round(usdtobgn, 2);
            Console.WriteLine(roundedbgn);
        }
    }
}
