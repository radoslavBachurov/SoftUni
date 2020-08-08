namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {

        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var employees = context
                .Genres
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Where(g => g.Purchases.Any())
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(s => s.Purchases.Count())//SelectMany(g => g.Purchases).Count()
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var jsonOutput = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonOutput;

        }


        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            PurchaseType purchaseType = Enum.Parse<PurchaseType>(storeType);

            var allPurchases = context.Purchases
                .Where(x => x.Type == purchaseType)
                .Select(x => new ExportPurchaseDTO
                {
                    CardId = x.Card.Id,
                    Game = new ExportGamedto { Title = x.Game.Name, Genre = x.Game.Genre.Name, Price = x.Game.Price },
                    Cvc = x.Card.Cvc,
                    Card = x.Card.Number,
                    Date = x.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
                })
                .ToArray();

            var sortedUsers = context.Users
                .ToArray()
                .Where(x => x.Cards.Any(c => c.Purchases.Any()))
                .Select(x => new ExportUsersByType
                {
                    username = x.Username,
                    Purchases = allPurchases
                                .Where(ap => (x.Cards.Select(c => c.Id).ToArray()).Contains(ap.CardId))
                                .ToArray()
                                .OrderBy(ap => DateTime.Parse(ap.Date, CultureInfo.InvariantCulture))
                                .ToArray(),

                    TotalSpent = allPurchases
                                .Where(ap => (x.Cards.Select(c => c.Id).ToArray()).Contains(ap.CardId))
                                .Sum(ap => ap.Game.Price)
                })
                .Where(x => x.Purchases.Length > 0)
                .ToArray()
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.username)
                .ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersByType[]), new XmlRootAttribute("Users"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, sortedUsers, GetXmlNamespaces());
            }

            return newSB.ToString();
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }
    }
}