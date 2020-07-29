using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
   
    public class UsersAndProductsDTO
    {
        [XmlElement("count")]
        public int count { get; set; }

        [XmlArray("users")]
        public List<UserDTO> users { get; set; }
    }

    [XmlType("User")]
    public class UserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductsDTO SoldProducts { get; set; }
    }

   
    public class SoldProductsDTO
    {
        [XmlElement("count")]
        public int count { get; set; }

        [XmlArray("products")]
        public List<ProductDTO> Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
