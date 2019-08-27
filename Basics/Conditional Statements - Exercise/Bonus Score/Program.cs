using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            double sumscore = 0;
            double bonuspoints = 0;
            
            if (score <= 100)
            {
                bonuspoints = 5;
                sumscore = score + 5;
            }
            else if (score > 100 && score <= 1000)
            {
                bonuspoints = score * 0.2;
                sumscore = score + (score * 0.2);
            }
            else if (score > 1000)
            {
                bonuspoints = score * 0.1;
                sumscore = score + (score * 0.1);
            }

            double evenscore = score % 2;
            double fiveScore = score % 10;
            if(evenscore == 0)
            {
                Console.WriteLine(bonuspoints+1);
                Console.WriteLine(sumscore+1);
            }

            else if (fiveScore == 5)
            {
                Console.WriteLine(bonuspoints+2);
                Console.WriteLine(sumscore+2);
            }
            else
            {
                Console.WriteLine(bonuspoints);
                Console.WriteLine(sumscore);
            }
        }
    }
}
