using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private RealEstateDBContext db;
        public PropertiesService(RealEstateDBContext db)
        {
            this.db = db;
        }

        public void Create(string district, int size, int? year, int price, string realEstateType, string buildingType, int? floor, int? maxFloors)
        {

            if (district == null)
            {
                return;
            }

            var property = new RealEstateProperty()
            {
                Size = size,
                Price = price,
                Floor = floor,
                TotalNumberOfFloors = maxFloors,
                YearOfConstruction = year
            };

            if (property.YearOfConstruction < 1800)
            {
                property.YearOfConstruction = null;
            }

            if (property.Floor <= 0)
            {
                property.Floor = null;
            }

            if (property.TotalNumberOfFloors <= 0)
            {
                property.TotalNumberOfFloors = null;
            }

            //District Set Up
            var districtEntity = this.db.Districts.FirstOrDefault(x => x.Name.Trim() == district);

            if (districtEntity == null)
            {
                districtEntity = new District()
                {
                    Name = district
                };
            }

            property.District = districtEntity;

            //BuildingType Set Up
            var buildingTypeEntity = this.db.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == buildingType);

            if (buildingTypeEntity == null)
            {
                buildingTypeEntity = new BuildingType()
                {
                    Name = buildingType
                };
            }

            property.BuildingType = buildingTypeEntity;

            //PropertyType Set Up
            var realEstateTypeEntity = this.db.RealEstateTypes.FirstOrDefault(x => x.Name.Trim() == realEstateType);

            if (realEstateTypeEntity == null)
            {
                realEstateTypeEntity = new RealEstateType()
                {
                    Name = realEstateType
                };
            }

            property.RealEstateType = realEstateTypeEntity;

            this.db.RealEstateProperties.Add(property);
            this.db.SaveChanges();

            this.UpdateTags(property.Id);
        }


        public IEnumerable<PropertyViewModel> Search(int minYear, int MaxYear, int minSize, int maxSize)
        {
            return this.db.RealEstateProperties.Where(x => x.YearOfConstruction >= minYear && x.YearOfConstruction <= MaxYear &&
                                                            x.Size >= minSize && x.Size <= maxSize)
                .Select(x => new PropertyViewModel()
                {
                    BuildingType = x.BuildingType.Name,
                    District = x.District.Name,
                    Floor = (x.Floor ?? 0).ToString() + "/" + (x.TotalNumberOfFloors ?? 0),
                    Price = x.Price,
                    PropertyType = x.RealEstateType.Name,
                    Size = x.Size,
                    Year = x.YearOfConstruction
                })
                .OrderBy(x => x.Price)
                .ToList();
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int MaxPrice)
        {
            return this.db.RealEstateProperties.Where(x => x.Price >= minPrice && x.Price <= MaxPrice)
                .Select(x => new PropertyViewModel()
                {
                    BuildingType = x.BuildingType.Name,
                    District = x.District.Name,
                    Floor = (x.Floor ?? 0).ToString() + "/" + (x.TotalNumberOfFloors ?? 0),
                    Price = x.Price,
                    PropertyType = x.RealEstateType.Name, 
                    Size = x.Size,
                    Year = x.YearOfConstruction
                })
                .OrderBy(x => x.Price)
                .ToList();
        }

        public void UpdateTags(int propertyId)
        {
            var property = this.db.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);
            property.Tags.Clear();

            if (property.YearOfConstruction.HasValue && property.YearOfConstruction <= 1990)
            {
                property.Tags.Add(new RealEstatePropertyTag()
                {
                    Tag = GetOrCreateTag("Old Building")
                });
            }

            if (property.Size > 120)
            {
                property.Tags.Add(new RealEstatePropertyTag()
                {
                    Tag = GetOrCreateTag("Huge Apartment")
                });
            }

            if (property.YearOfConstruction > 2010)
            {
                property.Tags.Add(new RealEstatePropertyTag()
                {
                    Tag = GetOrCreateTag("New Construction")
                });
            }

            if (property.Floor > property.TotalNumberOfFloors)
            {
                property.Tags.Add(new RealEstatePropertyTag()
                {
                    Tag = GetOrCreateTag("Last Floor")
                });
            }

            this.db.SaveChanges();
        }

        private Tag GetOrCreateTag(string tag)
        {
            var tagToAdd = this.db.Tags.FirstOrDefault(x => x.Name.Trim() == tag.Trim());

            if (tagToAdd == null)
            {
                tagToAdd = new Tag() { Name = tag };
            }

            return tagToAdd;
        }
    }


}

