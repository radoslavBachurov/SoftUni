using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //ResetDatabase(db);

            //exercise 8 
            //string inputSup = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
            //string result = ImportSuppliers(db, inputSup);
            //Console.WriteLine(result);

            //exercise 9 
            //string input = File.ReadAllText(@"..\..\..\Datasets\parts.json");
            //string result = ImportParts(db, input);
            //Console.WriteLine(result);

            //exercise 10

            //string input = File.ReadAllText(@"..\..\..\Datasets\cars.json");
            //string result = ImportCars(db, input);
            //Console.WriteLine(result);


            //exercise 11

            //string input = File.ReadAllText(@"..\..\..\Datasets\customers.json");
            //string result = ImportCustomers(db, input);
            //Console.WriteLine(result);


            //exercise 12

            //string input = File.ReadAllText(@"..\..\..\Datasets\sales.json");
            //string result = ImportSales(db, input);
            //Console.WriteLine(result);


            //exercise 13
            //string result = GetOrderedCustomers(db);
            //Console.WriteLine(result);


            ////exercise 14
            //string result = GetCarsFromMakeToyota(db);
            //Console.WriteLine(result);

            //////exercise 15
            //string result = GetLocalSuppliers(db);
            //Console.WriteLine(result);

            //exercise 16
            //string result = GetCarsWithTheirListOfParts(db);
            //Console.WriteLine(result);


            //exercise 17
            //string result = GetTotalSalesByCustomer(db);
            //Console.WriteLine(result);


            //exercise 18
            string result = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result);
        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var output = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            var count = output.Count();
            context.AddRange(output);
            context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersID = context.Suppliers.Select(x => new { x.Id }).ToList();
            var output = JsonConvert.DeserializeObject<List<Part>>(inputJson).Where(x => suppliersID.Any(a => a.Id == x.SupplierId));

            var count = output.Count();
            context.Parts.AddRange(output);
            context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDTOs = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            foreach (var carDTO in carsDTOs)
            {
                var car = new Car() { Make = carDTO.Make, Model = carDTO.Model, TravelledDistance = carDTO.TravelledDistance };

                context.Cars.Add(car);

                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    var carPart = new PartCar() { PartId = partId, Car = car };

                    context.PartCars.Add(carPart);
                }
            }

            context.SaveChanges();
            return $"Successfully imported {carsDTOs.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            var count = customers.Count();
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            var count = sales.Count();
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate).ThenBy(x => x.IsYoungDriver)
                .Select(x => new { x.Name, BirthDate = x.BirthDate.ToString("dd/MM/yyyy"), x.IsYoungDriver }).ToList();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new { x.Id, x.Make, x.Model, x.TravelledDistance })
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model).ThenByDescending(x => x.TravelledDistance).ToList();

            var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(x => x.IsImporter == false)
                .Select(x => new { Id = x.Id, Name = x.Name, PartsCount = x.Parts.Count() });

            var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsParts = context.Cars
                .Select(x => new
                {
                    car = new { x.Make, x.Model, x.TravelledDistance },
                    parts = x.PartCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                }).ToList();

            var carsPartsJson = JsonConvert.SerializeObject(carsParts, Formatting.Indented);

            return carsPartsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                 .Where(x => x.Sales.Any())
                 .Select(x => new
                 {
                     fullName = x.Name,
                     boughtCars = x.Sales.Count(),
                     spentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(p => p.Part.Price))

                 })
                 .OrderByDescending(x => x.spentMoney).ThenByDescending(x => x.boughtCars)
                 .ToList();

            var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var topSales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new { x.Car.Make, x.Car.Model, x.Car.TravelledDistance },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("f2"),
                    price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("f2"),
                    priceWithDiscount = ((x.Car.PartCars.Sum(p => p.Part.Price)) * ((100m - x.Discount) / 100m)).ToString("f2")
                }).ToList();

            var topSalesJson = JsonConvert.SerializeObject(topSales, Formatting.Indented);

            return topSalesJson;
        }
    }
}