using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class ToySelled
    {
        [Key]
        public int TradeId { get; set; }

        public DateTime TradeDate { get; set; } = DateTime.Now;

        [Required]
        public int ToyId { get; set; }

        [Required]
        public Toy Toy { get; set; }


        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}
