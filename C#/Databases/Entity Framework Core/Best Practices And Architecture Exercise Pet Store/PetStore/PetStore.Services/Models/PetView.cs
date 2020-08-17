using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models
{
    public class PetView
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Breed { get; set; }
    }
}
