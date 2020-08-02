using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
    public class AuthorBook
    {
        [Key]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Key]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}



