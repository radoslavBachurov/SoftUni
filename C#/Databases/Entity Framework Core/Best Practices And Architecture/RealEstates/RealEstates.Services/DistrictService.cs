using RealEstates.Data;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictsService
    {
        private RealEstateDBContext db;
        public DistrictService(RealEstateDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10)
        {
            return this.db.Districts
                .Select(x => new DistrictViewModel
                {
                    AveragePrice = x.RealEstateProperties.Average(p => p.Price),
                    maxPrice = x.RealEstateProperties.Max(p => p.Price),
                    minPrice = x.RealEstateProperties.Min(p => p.Price),
                    Name = x.Name,
                    PropertiesCount = x.RealEstateProperties.Count()
                })
                .OrderByDescending(x => x.AveragePrice)
                .Take(count)
                .ToList();

        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            return this.db.Districts
                 .Select(x => new DistrictViewModel
                 {
                     AveragePrice = x.RealEstateProperties.Average(p => p.Price),
                     maxPrice = x.RealEstateProperties.Max(p => p.Price),
                     minPrice = x.RealEstateProperties.Min(p => p.Price),
                     Name = x.Name,
                     PropertiesCount = x.RealEstateProperties.Count()
                 })
                 .OrderByDescending(x => x.PropertiesCount)
                 .Take(count)
                 .ToList(); 
        }
    }
}
