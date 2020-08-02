namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using System.IO;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Linq;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectDTO[]), new XmlRootAttribute("Projects"));
            StringReader rdr = new StringReader(xmlString);
            ProjectDTO[] projects = ((ProjectDTO[])serializer.Deserialize(rdr)).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var prj in projects)
            {
                if (IsValid(prj) &&
                    TryParseDateTime(prj.OpenDate))
                {
                    var openDateProject = ParseDateTime(prj.OpenDate);
                    var dueDateProject = TryParseDateTime(prj.DueDate) ? (DateTime?)ParseDateTime(prj.DueDate) : null;

                    Project newProject = new Project()
                    {
                        Name = prj.Name,
                        OpenDate = openDateProject,
                        DueDate = dueDateProject,
                        Tasks = prj.Tasks.Where(x => ValidateTask(x, openDateProject, dueDateProject, sb))
                                        .Select(x => new Task
                                        {
                                            Name = x.Name,
                                            OpenDate = ParseDateTime(x.OpenDate),
                                            DueDate = ParseDateTime(x.DueDate),
                                            LabelType = (LabelType)x.LabelType,
                                            ExecutionType = (ExecutionType)x.ExecutionType
                                        }).ToList()
                    };

                    context.Projects.Add(newProject);
                    sb.AppendLine(string.Format(SuccessfullyImportedProject, newProject.Name, newProject.Tasks.Count()));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }


            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool ValidateTask(ImportTaskDTO dto, DateTime prOpen, DateTime? prDue, StringBuilder sb)
        {
            bool validate = true;

            if (!IsValid(dto) ||
                !TryParseDateTime(dto.OpenDate) ||
                !TryParseDateTime(dto.DueDate) ||
                ParseDateTime(dto.OpenDate) < prOpen ||
                ParseDateTime(dto.DueDate) > prDue)

            {
                sb.AppendLine(ErrorMessage);
                return false;
            }

            return validate;
        }

        public static DateTime ParseDateTime(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static bool TryParseDateTime(string date)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None,
                              out dateValue))
            {
                return true;
            }

            return false;
        }


        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var tasks = context.Tasks.Select(x => x.Id).ToArray();
            var employeesDTO = JsonConvert.DeserializeObject<List<ImportEmployeesDTO>>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (var employeeDTO in employeesDTO)
            {
                if (IsValid(employeeDTO))
                {
                    Employee newEmployee = new Employee()
                    {
                        Username = employeeDTO.Username,
                        Email = employeeDTO.Username,
                        Phone = employeeDTO.Phone
                    };
                    context.Employees.Add(newEmployee);

                    int count = 0;
                    foreach (var task in employeeDTO.Tasks.Distinct())
                    {
                        if (tasks.Any(x => x == task))
                        {
                            EmployeeTask newTask = new EmployeeTask()
                            {
                                Employee = newEmployee,
                                TaskId = task
                            };

                            context.EmployeesTasks.Add(newTask);
                            count++;
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employeeDTO.Username, count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}