using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Text;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var db = new RealEstateDBContext();
            db.Database.Migrate();

            IPropertiesService propertiesService = new PropertiesService(db);
        }
    }
}
