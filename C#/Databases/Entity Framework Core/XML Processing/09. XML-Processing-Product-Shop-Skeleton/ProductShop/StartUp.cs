using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //ResetDatabase(db);

            //////Task 1
            //string inputUsers = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            //var resultUsers = ImportUsers(db, inputUsers);
            //Console.WriteLine(resultUsers);

            ////Task 2
            //string inputProducts = File.ReadAllText(@"..\..\..\Datasets\products.xml");
            //var resultProducts = ImportProducts(db, inputProducts);
            //Console.WriteLine(resultProducts);

            ////Task 3
            //string inputCategories = File.ReadAllText(@"..\..\..\Datasets\categories.xml");
            //var resultCategories = ImportCategories(db, inputCategories);
            //Console.WriteLine(resultCategories);

            ////Task 4
            //string inputCatPro = File.ReadAllText(@"..\..\..\Datasets\categories-products.xml");
            //var resultCatPro = ImportCategoryProducts(db, inputCatPro);
            //Console.WriteLine(resultCatPro);

            ////Task 5
            //var result = GetProductsInRange(db);
            //Console.WriteLine(result);

            ////Task 6
            //var result = GetSoldProducts(db);
            //Console.WriteLine(result);


            ////Task 7
            //var result = GetCategoriesByProductsCount(db);
            //Console.WriteLine(result);

            ////Task 8
            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);

        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was deleted");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was created");
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User[]), new XmlRootAttribute("Users"));
            StringReader rdr = new StringReader(inputXml);
            User[] users = (User[])serializer.Deserialize(rdr);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product[]), new XmlRootAttribute("Products"));
            StringReader rdr = new StringReader(inputXml);
            Product[] products = (Product[])serializer.Deserialize(rdr);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Category[]), new XmlRootAttribute("Categories"));
            StringReader rdr = new StringReader(inputXml);
            Category[] categories = ((Category[])serializer.Deserialize(rdr)).Where(x => x.Name != null).ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var products = context.Products.Select(x => new { x.Id }).ToList();
            var categories = context.Categories.Select(x => new { x.Id }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryProduct[]), new XmlRootAttribute("CategoryProducts"));
            StringReader rdr = new StringReader(inputXml);
            CategoryProduct[] categoriesProducts = ((CategoryProduct[])serializer.Deserialize(rdr))
                .Where(x => products.Any(p => p.Id == x.ProductId) && categories.Any(c => c.Id == x.CategoryId)).ToArray();


            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var sortedProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ExportProductDTO { Name = x.Name, Price = x.Price, Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName })
                .ToArray();

            var builder = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductDTO[]), new XmlRootAttribute("Products"));
            var stringwriter = new StringWriter(builder);
            using (stringwriter)
            {
                serializer.Serialize(stringwriter, sortedProducts, GetXmlNamespaces());
            }

            return builder.ToString();
        }



        public static string GetSoldProducts(ProductShopContext context)
        {
            var sortedUsers = context.Users.Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                .Select(x => new ExportSoldProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new SoldProductDTO { Name = p.Name, Price = p.Price })
                    .ToList()
                })
                .Take(5)
                .ToArray();

            var builder = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSoldProductsDTO[]), new XmlRootAttribute("Users"));
            var stringwriter = new StringWriter(builder);
            using (stringwriter)
            {
                serializer.Serialize(stringwriter, sortedUsers, GetXmlNamespaces());
            }

            return builder.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var sortedCategories = context.Categories
                .Select(x => new ExportCategoryInfoDTO
                {
                    Name = x.Name,
                    NumberOfProducts = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalPrice = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.NumberOfProducts).ThenBy(x => x.TotalPrice)
                .ToArray();

            var builder = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryInfoDTO[]), new XmlRootAttribute("Categories"));
            var stringwriter = new StringWriter(builder);
            using (stringwriter)
            {
                serializer.Serialize(stringwriter, sortedCategories, GetXmlNamespaces());
            }

            return builder.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var allUsers = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x=>new {x.FirstName,x.LastName,x.Age,x.ProductsSold })
                .OrderByDescending(x => x.ProductsSold.Count())
                .ToArray();

            var sortedUsers = new UsersAndProductsDTO()
            {
                count = allUsers.Count(),
                users = allUsers.Take(10)
                .Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductsDTO
                    {
                        count = x.ProductsSold.Count(),
                        Products = x.ProductsSold
                            .Select(s => new ProductDTO
                            {
                                Name = s.Name,
                                Price = s.Price
                            })
                            .OrderByDescending(s => s.Price)
                            .ToList()
                    }
                }).ToList()
            };

            var builder = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(UsersAndProductsDTO), new XmlRootAttribute("Users"));
            var stringwriter = new StringWriter(builder);
            using (stringwriter)
            {
                serializer.Serialize(stringwriter, sortedUsers, GetXmlNamespaces());
               
            }

            return builder.ToString();
        }
    }
}