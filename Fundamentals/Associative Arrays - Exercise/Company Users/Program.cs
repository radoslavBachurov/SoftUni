using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, List<string>> companyEmployesList = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" -> ").ToArray();
                string company = commandArr[0];
                string employe = commandArr[1];

                if(!companyEmployesList.ContainsKey(company))
                {
                    companyEmployesList.Add(company, new List<string>());
                }

                if(!companyEmployesList[company].Contains(employe))
                {
                    companyEmployesList[company].Add(employe);
                }
            }

            foreach (var item in companyEmployesList.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var employe in item.Value)
                {
                    Console.WriteLine($"-- {employe}");
                }        
            }
        }
    }
}
