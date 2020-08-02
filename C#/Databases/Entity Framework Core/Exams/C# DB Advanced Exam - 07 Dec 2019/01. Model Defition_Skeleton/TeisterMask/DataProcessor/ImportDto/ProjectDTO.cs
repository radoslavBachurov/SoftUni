using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectDTO
    {
        [XmlElement("Name"),MinLength(2), MaxLength(40), Required]
        public string Name { get; set; }

        [XmlElement("OpenDate"), Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTaskDTO[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ImportTaskDTO
    {
        [XmlElement("Name"), MinLength(2), MaxLength(40), Required]
        public string Name { get; set; }

        [XmlElement("OpenDate"), Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate"), Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType"),Required,Range(0,3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType"), Required, Range(0, 4)]
        public int LabelType { get; set; }
    }
}

  
 

