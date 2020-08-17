using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required,MinLength(2),MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(30)]
        public string LastName { get; set; }

        [Required,Range(18,100)]
        public int Age { get; set; }

        public virtual ICollection<FoodSelled> FoodsBuyed { get; set; } = new HashSet<FoodSelled>();
        public virtual ICollection<ToySelled> ToysBuyed { get; set; } = new HashSet<ToySelled>();
        public virtual ICollection<PetSelled> PetsBuyed { get; set; } = new HashSet<PetSelled>();
    }
}
