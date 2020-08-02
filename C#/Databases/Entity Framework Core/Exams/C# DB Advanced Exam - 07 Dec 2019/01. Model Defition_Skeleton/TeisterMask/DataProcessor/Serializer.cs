namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                 .Where(x => x.Tasks.Any())
                 .ToArray()
                 .Select(x => new ExportProjectsTasksDTO
                 {
                     TasksCount = x.Tasks.Count(),
                     HasEndDate = x.DueDate == null ? "No" : "Yes",
                     ProjectName = x.Name,
                     Tasks = x.Tasks.Select(t => new ExportTaskDTO
                     {
                         Name = t.Name,
                         Label = t.LabelType.ToString()
                     })
                         .ToArray()
                         .OrderBy(t => t.Name)
                         .ToArray()
                 })
                 .ToArray()
                 .OrderByDescending(x => x.Tasks.Count())
                 .ThenBy(x => x.ProjectName)
                 .ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectsTasksDTO[]), new XmlRootAttribute("Projects"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, projects, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees.Where(x => x.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(x => new ExportEmployeesTasksDTO
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                            .Where(p => p.Task.OpenDate >= date)
                            .OrderByDescending(p => p.Task.DueDate)
                            .ThenBy(p => p.Task.Name)
                            .Select(p => new ExportTasksDTO
                            {
                                DueDate = p.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                OpenDate = p.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                ExecutionType = p.Task.ExecutionType.ToString(),
                                LabelType = p.Task.LabelType.ToString(),
                                TaskName = p.Task.Name
                            })
                            .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var employeesJson = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return employeesJson.ToString();
        }
    }
}