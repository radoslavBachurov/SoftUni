using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Toy
    {
        [Key]
        public int ToyId { get; set; }

        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required, Range(1, 200)]
        public decimal Price { get; set; }

        public virtual ICollection<ToySelled> Customers { get; set; } = new HashSet<ToySelled>();
}
}
