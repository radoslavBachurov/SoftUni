namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors.Select(x => new ExportAuthorBooksDTO
            {
                AuthorName = x.FirstName + " " + x.LastName,
                Books = x.AuthorsBooks
                        .OrderByDescending(a => a.Book.Price)
                        .Select(a => new ExportBookDTO
                        {
                            BookName = a.Book.Name,
                            BookPrice = a.Book.Price.ToString("f2")
                        }).ToArray()
            })
            .ToArray()
            .OrderByDescending(x => x.Books.Length)
            .ThenBy(x => x.AuthorName)
            .ToArray();

            var authorsJson = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return authorsJson;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
               .Where(x => x.Genre == Data.Models.Enums.Genre.Science && x.PublishedOn < date)
               .ToArray()
               .OrderByDescending(x => x.Pages)
               .ThenByDescending(x => x.PublishedOn)
               .Take(10)
               .Select(x => new ExportBooksDTO
               {
                   Date = x.PublishedOn.ToString("MM/dd/yyyy"),
                   Pages = x.Pages.ToString(),
                   Name = x.Name
               })
              .ToArray();

            var builder = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBooksDTO[]), new XmlRootAttribute("Books"));
            var stringwriter = new StringWriter(builder);
            using (stringwriter)
            {
                serializer.Serialize(stringwriter, books, GetXmlNamespaces());
            }

            return builder.ToString();
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }
    }
}