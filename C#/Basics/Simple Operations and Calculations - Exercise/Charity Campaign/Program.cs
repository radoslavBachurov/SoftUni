using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakesaday = int.Parse(Console.ReadLine());
            int gofretsaday = int.Parse(Console.ReadLine());
            int panecakesaday = int.Parse(Console.ReadLine());
            double cakesnumber = days * cooks * cakesaday;
            double gofretsnumber = days * cooks * gofretsaday;
            double panecakesnumber = days * cooks * panecakesaday;
            double cakesdfunds = cakesnumber * 45;
            double gofretsfunds = gofretsnumber * 5.8;
            double panecakesfunds = panecakesnumber * 3.2;
            double fundsraised = cakesdfunds + gofretsfunds + panecakesfunds;
            double endfunds = fundsraised - (fundsraised / 8);
            Console.WriteLine($"{endfunds:f2}");

        }
    }
}
