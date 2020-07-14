namespace MiniORM.App
{
    using System;
    using System.Linq;
    using Data;
    using Data.Entities;

    class Startup
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=DESKTOP-FDQOU2P;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee()
            {
                FirstName = "asdqwd12",
                LastName = "d12d1d2",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

           context.SaveChanges();
        }
    }
}
