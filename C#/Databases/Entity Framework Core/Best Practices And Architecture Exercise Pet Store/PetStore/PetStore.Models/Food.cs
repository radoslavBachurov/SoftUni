using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required, Range(1, 1000)]
        public decimal Price { get; set; }

        public virtual ICollection<FoodSelled> Customers { get; set; } = new HashSet<FoodSelled>();
    }
}
