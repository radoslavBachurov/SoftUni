using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inMetric = Console.ReadLine();
            string outMetric = Console.ReadLine();

            switch (inMetric)
            {
                case "mm":
                    switch (outMetric)
                    {
                        case "cm":
                            Console.WriteLine($"{number * 0.1:f3}");
                            break;
                        case "m":
                            Console.WriteLine($"{number * 0.001:f3}");
                            break;
                    }
                    break;
                case "cm":
                    switch (outMetric)
                    {
                        case "mm":
                            Console.WriteLine($"{number * 10:f3}");
                            break;
                        case "m":
                            Console.WriteLine($"{number * 0.01:f3}");
                            break;
                    }
                    break;
                            
                case "m":
                    switch (outMetric)
                    {
                        case "cm":
                            Console.WriteLine($"{number * 100:f3}");
                            break;
                        case "mm":
                            Console.WriteLine($"{number*1000:f3}");
                            break;
                    }
                    break;
                                    
            }
        }
    }
}
