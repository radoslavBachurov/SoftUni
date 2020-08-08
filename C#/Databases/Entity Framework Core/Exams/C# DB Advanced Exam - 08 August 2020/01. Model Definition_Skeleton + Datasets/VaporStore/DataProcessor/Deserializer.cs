namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {

            var gamesList = new List<Game>();
            var gameTags = new List<GameTag>();

            var games = JsonConvert.DeserializeObject<List<ImportGamesDTO>>(jsonString);

            var newSB = new StringBuilder();

            foreach (var game in games)
            {
                DateTime dateValue;
                if (IsValid(game) &&
                    game.Tags.Any() &&
                    (DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue)))
                {
                    var developers = context.Developers.Where(x => x.Name == game.Developer).ToList();
                    if (!developers.Any())
                    {
                        var newDeveloper = new Developer() { Name = game.Developer };
                        context.Developers.Add(newDeveloper);
                    }

                    var genres = context.Genres.Where(x => x.Name == game.Genre).ToList();
                    if (!genres.Any())
                    {
                        var newGenre = new Genre() { Name = game.Genre };
                        context.Genres.Add(newGenre);
                    }
                    context.SaveChanges();

                    var developerId = context.Developers.Where(x => x.Name == game.Developer).Select(x => x.Id).FirstOrDefault();
                    var genreId = context.Genres.Where(x => x.Name == game.Genre).Select(x => x.Id).FirstOrDefault();



                    Game newGame = new Game()
                    {
                        Name = game.Name,
                        Price = game.Price,
                        ReleaseDate = dateValue,
                        DeveloperId = developerId,
                        GenreId = genreId
                    };
                    context.Games.Add(newGame);
                    context.SaveChanges();

                    var tags = context.Tags.Select(x => new { x.Name, x.Id }).ToList();
                    foreach (var tag in game.Tags)
                    {
                        if (!tags.Any(x => tag == x.Name))
                        {
                            var newTag = new Tag() { Name = tag };
                            context.Tags.Add(newTag);
                            context.GameTags.Add(new GameTag() { Game = newGame, Tag = newTag });
                            context.SaveChanges();
                        }
                        else
                        {
                            var tagId = context.Tags.Where(x => x.Name == tag).Select(x => x.Id).FirstOrDefault();
                            context.GameTags.Add(new GameTag() { Game = newGame, TagId = tagId });
                            context.SaveChanges();
                        }
                    }
                    newSB.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");
                }
                else
                {
                    newSB.AppendLine("Invalid Data");

                }
            }


            //context.SaveChanges();

            return newSB.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var users = JsonConvert.DeserializeObject<List<ImportUsersDTO>>(jsonString);
            var newSB = new StringBuilder();

            foreach (var user in users)
            {
                if (IsValid(user) &&
                    user.Cards.Any() &&
                    user.Cards.All(x => IsValid(x)) &&
                    user.Cards.All(x => Enum.TryParse(x.Type, out CardType type)))
                {
                    var newUser = new User()
                    {
                        FullName = user.FullName,
                        Age = user.Age,
                        Email = user.Email,
                        Username = user.Username,
                        Cards = user.Cards.Select(x => new Card
                        {
                            Cvc = x.CVC,
                            Number = x.Number,
                            Type = (CardType)Enum.Parse(typeof(CardType), x.Type, true)
                        }).ToArray()
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    newSB.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count()} cards");
                }
                else
                {
                    newSB.AppendLine("Invalid Data");
                }
            }

            return newSB.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchasesDTO[]), new XmlRootAttribute("Purchases"));
            StringReader rdr = new StringReader(xmlString);
            ImportPurchasesDTO[] purchasesDTO = (ImportPurchasesDTO[])serializer.Deserialize(rdr);

            var newSB = new StringBuilder();

            foreach (var purchase in purchasesDTO)
            {
                int? cardId = context.Cards.Where(x => x.Number == purchase.Card).Select(x => x.Id).FirstOrDefault();
                int? gameId = context.Games.Where(x => x.Name == purchase.Title).Select(x => x.Id).FirstOrDefault();

                DateTime dateValue;
                if (IsValid(purchase) &&
                    cardId != null &&
                    gameId != null &&
                    DateTime.TryParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue) &&
                       Enum.TryParse(purchase.Type, out PurchaseType type))
                {
                    var newPurchase = new Purchase()
                    {
                        CardId = (int)cardId,
                        Date = dateValue,
                        GameId = (int)gameId,
                        Type = type,
                        ProductKey = purchase.Key,
                    };

                    context.Purchases.Add(newPurchase);
                    context.SaveChanges();

                    var username = context.Cards.Where(x => x.Number == purchase.Card).Select(x => x.User.Username).FirstOrDefault();
                    newSB.AppendLine($"Imported {purchase.Title} for {username}");
                }
                else
                {
                    newSB.AppendLine("Invalid Data");
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