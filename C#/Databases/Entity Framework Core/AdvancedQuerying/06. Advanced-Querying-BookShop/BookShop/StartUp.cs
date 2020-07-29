namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            
            
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            Enum.TryParse(FirstCharToUpper(command), out AgeRestriction myStatus);
            var bookTitles = context.Books.Where(x => x.AgeRestriction == myStatus).Select(x => new { x.Title }).ToList();
            StringBuilder newSB = new StringBuilder();

            foreach (var title in bookTitles.OrderBy(x => x.Title))
            {
                newSB.AppendLine($"{title.Title}");
            }

            return newSB.ToString().TrimEnd(); ;

        }

        public static string FirstCharToUpper(string input)
        {
            input = input.ToLower();
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context.Books.Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000).Select(x => new { x.Title, x.BookId }).ToList();
            StringBuilder newSB = new StringBuilder();

            foreach (var title in bookTitles.OrderBy(x => x.BookId))
            {
                newSB.AppendLine($"{title.Title}");
            }

            return newSB.ToString().TrimEnd(); ;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookTitles = context.Books.Where(x => x.Price > 40).Select(x => new { x.Title, x.Price }).ToList();
            StringBuilder newSB = new StringBuilder();

            foreach (var title in bookTitles.OrderByDescending(x => x.Price))
            {
                newSB.AppendLine($"{title.Title} - ${title.Price:f2}");
            }

            return newSB.ToString().TrimEnd(); ;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context.Books.Where(x => (x.ReleaseDate).Value.Year != year).Select(x => new { x.Title, x.BookId }).ToList();
            StringBuilder newSB = new StringBuilder();

            foreach (var title in bookTitles.OrderBy(x => x.BookId))
            {
                newSB.AppendLine($"{title.Title}");
            }

            return newSB.ToString().TrimEnd(); ;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var bookColl = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
            var bookTitles = context.BooksCategories
                .Where(x => bookColl.Contains(x.Category.Name.ToLower()))
                .Select(x => new { x.Book.Title }).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var title in bookTitles.OrderBy(x => x.Title))
            {
                newSB.AppendLine($"{title.Title}");
            }

            return newSB.ToString().TrimEnd();

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            DateTime myDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var bookTitles = context.Books
                .Where(x => x.ReleaseDate < myDate)
                .Select(x => new { x.Title, x.EditionType, x.Price, x.ReleaseDate }).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var title in bookTitles.OrderByDescending(x => x.ReleaseDate))
            {
                newSB.AppendLine($"{title.Title} - {title.EditionType} - ${title.Price:f2}");
            }

            return newSB.ToString().TrimEnd();

        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authors = context.Authors
                 .Where(a => a.FirstName.EndsWith(input.ToLower()))
                 .Select(x => new { x.FirstName, x.LastName }).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var author in authors.OrderBy(x => $"{x.FirstName} {x.LastName}"))
            {
                newSB.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return newSB.ToString().TrimEnd();

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(a => a.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new { x.Title }).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var title in titles.OrderBy(x => x.Title))
            {
                newSB.AppendLine($"{title.Title}");
            }

            return newSB.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titles = context.Books
               .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
               .Select(x => new { x.Title, x.Author.FirstName, x.Author.LastName, x.BookId }).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var title in titles.OrderBy(x => x.BookId))
            {
                newSB.AppendLine($"{title.Title} ({title.FirstName} {title.LastName})");
            }

            return newSB.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var number = context.Books.Where(x => x.Title.Length > lengthCheck).Select(x => new { x.Title }).ToList().Count();

            return number;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var coppies = context.Authors
                .Select(x => new { Author = x.FirstName + " " + x.LastName, Coppies = x.Books.Sum(x => x.Copies) })
                .ToList();


            StringBuilder newSB = new StringBuilder();

            foreach (var author in coppies.OrderByDescending(x => x.Coppies))
            {
                newSB.AppendLine($"{author.Author} - {author.Coppies}");
            }

            return newSB.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profit = context.Categories
                .Select(x => new { x.Name, Profit = x.CategoryBooks.Sum(a => a.Book.Copies * a.Book.Price) })
                .ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var gendre in profit.OrderByDescending(x => x.Profit).ThenBy(x => x.Name))
            {
                newSB.AppendLine($"{gendre.Name} ${gendre.Profit:f2}");
            }

            return newSB.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .Select(x => new
                {
                    x.Name,
                    recentBooks = x.CategoryBooks.Select(s => new { s.Book.Title, s.Book.ReleaseDate })
                .OrderByDescending(a => a.ReleaseDate).Take(3).ToList()
                }).ToList();

            StringBuilder newSB = new StringBuilder();

            foreach (var book in books.OrderBy(x => x.Name))
            {
                newSB.AppendLine($"--{book.Name}");

                foreach (var item in book.recentBooks)
                {
                    newSB.AppendLine($"{item.Title} ({item.ReleaseDate.Value.Year})");
                }
            }

            return newSB.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();
            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count();
        }

       
    }
}
