using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class PetSelled
    {
        [Key]
        public int TradeId { get; set; }

        public DateTime TradeDate { get; set; } = DateTime.Now;

        [Required]
        public int PetId { get; set; }

        [Required]
        public Pet Pet { get; set; }


        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}
