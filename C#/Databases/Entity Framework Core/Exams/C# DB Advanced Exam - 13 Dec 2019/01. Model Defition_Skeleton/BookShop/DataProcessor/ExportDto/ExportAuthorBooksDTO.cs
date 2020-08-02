using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ExportDto
{
    public class ExportAuthorBooksDTO
    {
       
        public string AuthorName { get; set; }
        public ExportBookDTO[] Books { get; set; }
    }

    public class ExportBookDTO
    {
        public string BookName { get; set; }
        public string BookPrice { get; set; }
    }

}

