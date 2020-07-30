using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstates.Models
{
    public class RealEstateProperty
    {
        public RealEstateProperty()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        [Key]
        public int Id { get; set; }

        public int Size { get; set; }

        public int? Floor { get; set; }

        public int? TotalNumberOfFloors { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public int? YearOfConstruction { get; set; }

        public int RealEstateTypeId { get; set; }

        public virtual RealEstateType RealEstateType { get; set; }

        public int BuildingTypeId { get; set; }

        public virtual BuildingType BuildingType { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
