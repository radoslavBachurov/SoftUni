using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using static CarDealer.DTO.CarPartsDTO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //ResetDatabase(db);

            //TASK 9
            //var result = ImportSuppliers(db, File.ReadAllText(@"..\..\..\Datasets\suppliers.xml"));
            //Console.WriteLine(result);

            //TASK 10
            //var result = ImportParts(db, File.ReadAllText(@"..\..\..\Datasets\parts.xml"));
            //Console.WriteLine(result);

            //TASK 11
            //var result = ImportCars(db, File.ReadAllText(@"..\..\..\Datasets\cars.xml"));
            //Console.WriteLine(result);

            //TASK 12
            //var result = ImportCustomers(db, File.ReadAllText(@"..\..\..\Datasets\customers.xml"));
            //Console.WriteLine(result);

            //TASK 13
            //var result = ImportSales(db, File.ReadAllText(@"..\..\..\Datasets\sales.xml"));
            //Console.WriteLine(result);

            //TASK 14
            //Console.WriteLine(GetCarsWithDistance(db));

            //TASK 15
            //Console.WriteLine(GetCarsFromMakeBmw(db));

            //TASK 16
            //Console.WriteLine(GetLocalSuppliers(db));

            //TASK 17
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));

            //TASK 18
            //Console.WriteLine(GetTotalSalesByCustomer(db));


            //TASK 19
            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        private static void ResetDatabase(CarDealerContext db)
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

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Supplier[]), new XmlRootAttribute("Suppliers"));
            StringReader rdr = new StringReader(inputXml);
            Supplier[] suppliers = (Supplier[])serializer.Deserialize(rdr);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var suppliersId = context.Suppliers.Select(x => new { x.Id }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(Part[]), new XmlRootAttribute("Parts"));
            StringReader rdr = new StringReader(inputXml);
            Part[] parts = ((Part[])serializer.Deserialize(rdr)).Where(x => suppliersId.Any(p => p.Id == x.SupplierId)).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var partsId = context.Parts.Select(x => new { x.Id }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDTO[]), new XmlRootAttribute("Cars"));
            StringReader rdr = new StringReader(inputXml);
            ImportCarDTO[] carsDTO = ((ImportCarDTO[])serializer.Deserialize(rdr)).ToArray();


            foreach (var car in carsDTO)
            {
                var newCar = new Car() { Make = car.Make, Model = car.Model, TravelledDistance = car.TravelledDistance };

                context.Cars.Add(newCar);

                foreach (var part in car.Parts.GroupBy(x => x.PartId).Select(g => g.First()))
                {
                    if (partsId.Any(x => x.Id == part.PartId))
                    {
                        context.PartCars.Add(new PartCar() { Car = newCar, PartId = part.PartId });
                    }
                }
            }

            context.SaveChanges();
            return $"Successfully imported {carsDTO.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Customer[]), new XmlRootAttribute("Customers"));
            StringReader rdr = new StringReader(inputXml);
            Customer[] customers = (Customer[])serializer.Deserialize(rdr);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {

            var carIds = context.Cars.Select(x => new { x.Id }).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(Sale[]), new XmlRootAttribute("Sales"));
            StringReader rdr = new StringReader(inputXml);
            Sale[] sales = ((Sale[])serializer.Deserialize(rdr)).Where(x => carIds.Any(r => r.Id == x.CarId)).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sortedCars = context.Cars.Where(x => x.TravelledDistance > 2000000)
                .Select(x => new ExportCarDTO { Make = x.Make, Model = x.Model, TravelledDistance = x.TravelledDistance })
                .OrderBy(x => x.Make).ThenBy(x => x.Model).Take(10).ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDTO[]), new XmlRootAttribute("cars"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sortedCars, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sortedCars = context.Cars.Where(x => x.Make == "BMW")
                .Select(x => new ExportCarsBMW { Id = x.Id, Model = x.Model, TravelledDistance = x.TravelledDistance })
                .OrderBy(x => x.Model).ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsBMW[]), new XmlRootAttribute("cars"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sortedCars, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var sortedSuppliers = context.Suppliers.Where(x => x.IsImporter == false)
                .Select(x => new ExportSupplierDTO { Id = x.Id, Name = x.Name, PartsCount = x.Parts.Count() }).ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSupplierDTO[]), new XmlRootAttribute("suppliers"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sortedSuppliers, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sortedCars = context.Cars
                .Select(x => new CarPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = context.PartCars
                        .Where(p => p.CarId == x.Id)
                        .Select(p => new PartDTO { Name = p.Part.Name, Price = p.Part.Price })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance).ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CarPartsDTO[]), new XmlRootAttribute("cars"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sortedCars, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            var sortedCustomers = context.Customers.Where(x => x.Sales.Any())
                .Select(x => new CustomerSalesDTO
                {
                    Name = x.Name,
                    BoughtCars = x.Sales.Count(),
                    MoneySpend = context.PartCars.Where(p => x.Sales.Any(s => s.CarId == p.CarId))
                                      .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.MoneySpend).ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CustomerSalesDTO[]), new XmlRootAttribute("customers"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sortedCustomers, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SalesDTO
                {
                    Name = x.Customer.Name,
                    Discount = x.Discount,
                    Car = new SalesCarDTO() { Make = x.Car.Make, Model = x.Car.Model, TravelledDistance = x.Car.TravelledDistance },
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    DiscountPrice = x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100.0m
                }).ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SalesDTO[]), new XmlRootAttribute("sales"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sales, GetXmlNamespaces());
            }

            return newSB.ToString();
        }
    }
}