﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesDTO
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required, XmlElement("Type")]
        public string Type { get; set; }

        [Required, RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$"),XmlElement("Key")]
        public string Key { get; set; }

        [Required, RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$"),XmlElement("Card")]
        public string Card { get; set; }

        [Required,XmlElement("Date")]
        public string Date { get; set; }
    }
}


