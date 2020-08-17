using PetStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public PetBreedType Breed { get; set; }

        [Required, Range(1, 80)]
        public int Age { get; set; }

        [Required]
        public PetGenderType Gender { get; set; }

        public bool IsSold => this.CustomerId == null ? false : true;

        [Required, Range(1, 10000)]
        public decimal Price { get; set; }

        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
