namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {

        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BookDTO[]), new XmlRootAttribute("Books"));
            StringReader rdr = new StringReader(xmlString);
            BookDTO[] booksDTO = (BookDTO[])serializer.Deserialize(rdr);

            ICollection<Book> books = new List<Book>();
            var newSB = new StringBuilder();

            foreach (var book in booksDTO)
            {
                if (IsValid(book))
                {
                    books.Add(new Book()
                    {
                        Name = book.Name,
                        Genre = (Genre)book.Genre,
                        Pages = book.Pages,
                        Price = book.Price,
                        PublishedOn = DateTime.ParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                    });

                    newSB.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }
                else
                {
                    newSB.AppendLine(ErrorMessage);
                }
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return newSB.ToString().Trim();

        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authors = JsonConvert.DeserializeObject<List<AuthorDTO>>(jsonString);

            var newSB = new StringBuilder();

            foreach (var author in authors)
            {
                var emails = context.Authors.Select(x => new { x.Email }).ToList();
                var books = context.Books.Select(x => x.Id).ToList();

                if (IsValid(author) &&
                    !emails.Any(x => x.Email == author.Email) &&
                    books.Intersect(author.Books.Where(x => x.Id != null).Select(x => int.Parse(x.Id)).ToArray()).Any() &&
                    author.Books.Count() > 0)
                {
                    var newAuthor = new Author()
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        Email = author.Email,
                        Phone = author.Phone,
                    };

                    context.Authors.Add(newAuthor);

                    int count = 0;
                    foreach (var book in author.Books.Where(x => x.Id != null).Select(x => int.Parse(x.Id)).Distinct())
                    {
                        if (books.Any(x => x == book))
                        {
                            var bookAuthor = new AuthorBook()
                            {
                                Author = newAuthor,
                                BookId = book
                            };
                            context.AuthorsBooks.Add(bookAuthor);
                            count++;
                        }
                    }

                    newSB.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, count));
                    context.SaveChanges();
                }
                else
                {
                    newSB.AppendLine(ErrorMessage);
                }
            }
            return newSB.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}