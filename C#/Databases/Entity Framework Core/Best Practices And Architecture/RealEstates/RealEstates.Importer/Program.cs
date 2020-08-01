using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstateDBContext();
            var newServise = new PropertiesService(db);

            var json = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");
            var data = JsonSerializer.Deserialize<JsonProperty[]>(json);

            foreach (var item in data)
            {
                newServise.Create(item.District, item.Size, item.Year, item.Price, item.Type, item.BuildingType, item.Floor, item.TotalFloors);
            }



        }
    }

    class JsonProperty
    {
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public string District { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string BuildingType { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
    }
}

