using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class FoodSelled
    {
        [Key]
        public int TradeId { get; set; }

        public DateTime TradeDate { get; set; } = DateTime.Now;

        [Required]
        public int FoodId { get; set; }

        [Required]
        public Food Food { get; set; }


        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}
