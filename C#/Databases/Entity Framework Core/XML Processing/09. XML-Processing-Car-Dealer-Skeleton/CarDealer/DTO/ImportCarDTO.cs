using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO
{
    [XmlType("Car")]
    public class ImportCarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartsListDTO[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartsListDTO
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}


