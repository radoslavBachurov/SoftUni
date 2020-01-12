using System;
using System.Collections.Generic;
using System.Linq;

namespace International_SoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<string> countryList = new List<string>();
            List<string> contestantList = new List<string>();
            List<double> pointsList = new List<double>();
            List<string> finalList = new List<string>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                countryList.Add(input[0]);
                contestantList.Add(input[1]);
                pointsList.Add(double.Parse(input[2]));
            }

            SettingUpFinishList(countryList,contestantList,pointsList,finalList);
        }

        private static void SettingUpFinishList(List<string> countryList, List<string> contestantList, List<double> pointsList, List<string> finalList)
        {
            List<double> contestantPoints = new List<double>();



        }
    }
}
