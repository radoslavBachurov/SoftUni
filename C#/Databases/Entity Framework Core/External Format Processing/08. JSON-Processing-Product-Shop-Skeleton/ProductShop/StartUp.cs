using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //ResetDatabase(db);

            //Exercise 1
            //string input = File.ReadAllText(@"../../../Datasets/users.json");
            //string count = ImportUsers(db, input);
            //Console.WriteLine(count);

            ////Exercise 2
            //string input = File.ReadAllText(@"../../../Datasets/products.json");
            //string count = ImportProducts(db, input);
            //Console.WriteLine(count);

            ////Exercise 3
            //string input = File.ReadAllText(@"../../../Datasets/categories.json");
            //string count = ImportCategories(db, input);
            //Console.WriteLine(count);

            ////Exercise 4
            //string input = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string count = ImportCategoryProducts(db, input);
            //Console.WriteLine(count);

            //Exercise 5
            //string result = GetProductsInRange(db);
            //Console.WriteLine(result);

            //Exercise 6
            //string result = GetSoldProducts(db);
            //Console.WriteLine(result);

            //Exercise 7
            //string result = GetCategoriesByProductsCount(db);
            //Console.WriteLine(result);

            //Exercise 7
            string result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            int count = users.Count();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            int count = products.Count();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson).Where(x => x.Name != null);
            var count = categories.Count();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            var count = categoriesProducts.Count();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var sortedProducts = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new { name = x.Name, price = x.Price, seller = x.Seller.FirstName + " " + x.Seller.LastName })
                .OrderBy(x => x.price).ToList();

            var sortedProductsJson = JsonConvert.SerializeObject(sortedProducts);

            return sortedProductsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sortedUsers = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                        .Where(a => a.BuyerId != null)
                        .Select(a => new
                        {
                            name = a.Name,
                            price = a.Price,
                            buyerFirstName = a.Buyer.FirstName,
                            buyerLastName = a.Buyer.LastName
                        }).ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var sortedUsersJson = JsonConvert.SerializeObject(sortedUsers, Formatting.Indented);

            return sortedUsersJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var sortedCategories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count())
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(a => a.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(a => a.Product.Price).ToString("F2")
                })
                .ToList();

            var sortedCategoriesJson = JsonConvert.SerializeObject(sortedCategories, Formatting.Indented);

            return sortedCategoriesJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var validUsers = context.Users.AsEnumerable()
                .Where(x => x.ProductsSold.Any(a => a.BuyerId != null))
                .OrderByDescending(x => x.ProductsSold.Count(c => c.Buyer != null));

            var output = new
            {
                usersCount = validUsers.Count(),
                users = validUsers.Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(b => b.Buyer != null),
                        products = x.ProductsSold.Where(b => b.Buyer != null).Select(d => new
                        {
                            name = d.Name,
                            price = d.Price
                        })
                    }
                }
                ).ToList()
            };


            var outputJson = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return outputJson;
        }
    }
}