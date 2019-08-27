using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeYear = Console.ReadLine();
            int holidaysPerYear = int.Parse(Console.ReadLine());
            int weekendsInHome = int.Parse(Console.ReadLine());

            //година = 48 уикенда
            //не е на работа 3/4 от уикендите в които е в софия
            //играе в събота когато не е на работа и не си пътува до родния град
            //играе в 2/3 от празничните дни
            //в роден град играе само в неделя
            //високосна година 15% повече волейбол

            int weekendsInSofia = 48 - weekendsInHome;
            double playInSofia = weekendsInSofia * 3.0 / 4;
            double holidayPlays = holidaysPerYear * 2.0 / 3;
            double allplays = holidayPlays + playInSofia + weekendsInHome;

            if (typeYear == "leap")
            {
                allplays = Math.Floor(allplays + (allplays * 0.15));
                Console.WriteLine($"{allplays}");


            }
            else if (typeYear == "normal")
            {
                allplays = Math.Floor(allplays);
                Console.WriteLine($"{allplays}");
            }


        }
    }
}
