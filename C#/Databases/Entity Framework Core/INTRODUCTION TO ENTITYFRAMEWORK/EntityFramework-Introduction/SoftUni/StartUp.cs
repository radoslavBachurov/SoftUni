using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var result = GetEmployeesByFirstNameStartingWithSa(db);
            Console.WriteLine(result);
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder newSB = new StringBuilder();
            var sortedEmployees = context.Employees
                .Select(x => new { x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary, x.EmployeeId })
                .OrderBy(x => x.EmployeeId).ToList();

            foreach (var employee in sortedEmployees)
            {
                newSB.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder newSB = new StringBuilder();

            var sortedEmployees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new { x.Salary, x.FirstName })
                .OrderBy(x => x.FirstName).ToList();

            foreach (var employee in sortedEmployees)
            {
                newSB.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder newSB = new StringBuilder();

            var sortedEmployees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new { x.FirstName, x.LastName, x.Salary, x.Department.Name })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            foreach (var employee in sortedEmployees)
            {
                newSB.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            employee.Address = newAdress;
            context.SaveChanges();

            StringBuilder newSB = new StringBuilder();

            var sortedAddresses = context.Employees
                .OrderByDescending(x => x.Address.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText)
                .ToList();

            foreach (var adress in sortedAddresses)
            {
                newSB.AppendLine($"{adress}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder newSB = new StringBuilder();

            var sortedEmployees = context.Employees
                .Take(10)
                .Where(x => x.EmployeesProjects.Any(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(x => new
                {
                    emFirstName = x.FirstName,
                    emLastName = x.LastName,
                    mFirstName = x.Manager.FirstName,
                    mLastName = x.Manager.LastName,
                    x.EmployeeId
                }).ToList();

            foreach (var employee in sortedEmployees)
            {
                newSB.AppendLine($"{employee.emFirstName} {employee.emLastName} - Manager: {employee.mFirstName} {employee.mLastName}");

                var projects = context.EmployeesProjects.Where(x => x.EmployeeId == employee.EmployeeId).Select(x => x.Project).ToList();

                foreach (var project in projects)
                {
                    if (project.EndDate is null)
                    {
                        newSB.AppendLine($"--{project.Name} - {project.StartDate} - not finished");
                    }
                    else
                    {
                        newSB.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                    }

                }
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder newSB = new StringBuilder();

            var sortedAddresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new { x.AddressText, x.Town.Name, Count = x.Employees.Count() })
                .ToList();


            foreach (var item in sortedAddresses)
            {
                newSB.AppendLine($"{item.AddressText}, {item.Name} - {item.Count} employees");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 09

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder newSB = new StringBuilder();

            var employee = context.Employees
                .First(x => x.EmployeeId == 147);

            newSB.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                newSB.AppendLine($"{project.Project.Name}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .Select(x => new { x.Name, x.Manager.FirstName, x.Manager.LastName, x.Employees });

            StringBuilder newSB = new StringBuilder();

            foreach (var department in departments.OrderBy(x => x.Employees.Count).ThenBy(x => x.Name))
            {
                newSB.AppendLine($"{department.Name} - {department.FirstName} {department.LastName}");

                foreach (var employee in department.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    newSB.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 11

        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastProjects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var project in lastProjects.OrderBy(x => x.Name))
            {
                newSB.AppendLine($"{project.Name}");
                newSB.AppendLine($"{project.Description}");
                newSB.AppendLine($"{project.StartDate}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 12

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" ||
                          x.Department.Name == "Tool Design" ||
                          x.Department.Name == "Marketing" ||
                          x.Department.Name == "Information Services");

            StringBuilder newSB = new StringBuilder();

            foreach (var employee in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                employee.Salary *= 1.12m;
                newSB.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            context.SaveChanges();
            return newSB.ToString().TrimEnd();
        }

        //Problem 13

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.ToLower().StartsWith("sa"))
                .Select(x => new { x.FirstName, x.LastName, x.JobTitle, x.Salary })
                .ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var employee in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                newSB.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 14

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .First(x => x.ProjectId == 2);

            var range = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            foreach (var item in context.EmployeesProjects)
            {
                context.EmployeesProjects.RemoveRange(range);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context.Projects.Take(10);

            StringBuilder newSB = new StringBuilder();

            foreach (var p in projects)
            {
                newSB.AppendLine($"{p.Name}");
            }

            return newSB.ToString().TrimEnd();
        }

        //Problem 15

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .First(x => x.Name == "Seattle");

            var adresses = context.Addresses
                .Where(x => x.TownId == town.TownId);

            var count = adresses.Count();

            var employees = context.Employees
                .Where(x => adresses.Any(e => e.AddressId == x.AddressId));

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            foreach (var address in adresses)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
