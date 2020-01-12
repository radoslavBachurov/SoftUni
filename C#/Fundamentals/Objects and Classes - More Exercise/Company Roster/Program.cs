using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<List<Employee>> departamentList = new List<List<Employee>>();
            AddingEmployees(count, departamentList);
            Sorting(departamentList);
        }

        private static void Sorting(List<List<Employee>> departamentList)
        {

            int highindex = 0;
            decimal highSum = 0;

            for (int i = 0; i < departamentList.Count; i++)
            {
                decimal sum = 0;

                foreach (var item in departamentList[i])
                {
                    sum += item.Salary;
                }

                sum /= departamentList[i].Count;

                if (sum > highSum)
                {
                    highindex = i;
                    highSum = sum;
                }
                
            }

            List<Employee> winDepartament = departamentList[highindex].ToList();

            Console.WriteLine($"Highest Average Salary: {winDepartament[0].Departament}");

            foreach (var employee in winDepartament.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }

        private static void AddingEmployees(int count, List<List<Employee>> departamentList)
        {
            for (int i = 0; i < count; i++)
            {
                string[] employeeInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string employee = employeeInfo[0];
                string departament = employeeInfo[2];
                decimal salary = decimal.Parse(employeeInfo[1]);
                Employee newEmployee = new Employee(employee, departament, salary);

                if (departamentList.Count == 0)
                {
                    departamentList.Add(new List<Employee>());
                    departamentList[0].Add(newEmployee);
                    continue;
                }

                bool addedEmployee = false;
                foreach (var item in departamentList)
                {
                    if (item.Any(x => x.Departament == departament))
                    {
                        item.Add(newEmployee);
                        addedEmployee = true;
                    }
                }

                if (!addedEmployee)
                {
                    departamentList.Add(new List<Employee>());
                    departamentList[departamentList.Count - 1].Add(newEmployee);
                }

            }
        }
    }
    class Employee
    {
        public Employee(string name, string departament, decimal salary)
        {
            Name = name;
            Departament = departament;
            Salary = salary;
        }
        public string Name { get; set; }
        public string Departament { get; set; }
        public decimal Salary { get; set; }
    }
}
