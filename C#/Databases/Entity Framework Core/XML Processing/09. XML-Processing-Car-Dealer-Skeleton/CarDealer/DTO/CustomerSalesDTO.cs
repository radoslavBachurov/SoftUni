﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO
{
    [XmlType("customer")]
    public class CustomerSalesDTO
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }


        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }


        [XmlAttribute("spent-money")]
        public decimal MoneySpend { get; set; }
    }
}


