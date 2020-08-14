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
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();

            var inputGames = JsonConvert.DeserializeObject<List<ImportGamesDTO>>(jsonString);

            var newSB = new StringBuilder();

            foreach (var game in inputGames)
            {
                DateTime dateValue;

                if (IsValid(game) &&
                    game.Tags.Any() &&
                    (DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue)))
                {

                    Game newGame = new Game();

                    var newDeveloper = developers.Where(x => x.Name == game.Developer).FirstOrDefault();
                    if (newDeveloper == null)
                    {
                        newDeveloper = new Developer() { Name = game.Developer };
                        developers.Add(newDeveloper);
                    }

                    newGame.Developer = newDeveloper;

                    var newGenre = genres.Where(x => x.Name == game.Genre).FirstOrDefault();
                    if (newGenre == null)
                    {
                        newGenre = new Genre() { Name = game.Genre };
                        genres.Add(newGenre);
                    }

                    newGame.Genre = newGenre;
                    newGame.Name = game.Name;
                    newGame.Price = game.Price;
                    newGame.ReleaseDate = dateValue;

                    foreach (var tag in game.Tags)
                    {
                        if (String.IsNullOrEmpty(tag))
                        {
                            continue;
                        }

                        if (!tags.Any(x => tag == x.Name))
                        {
                            var newTag = new Tag() { Name = tag };
                            tags.Add(newTag);
                            newGame.GameTags.Add(new GameTag() { Game = newGame, Tag = newTag });
                        }
                        else
                        {
                            var tagToAdd = tags.Where(x => x.Name == tag).FirstOrDefault();
                            newGame.GameTags.Add(new GameTag() { Game = newGame, Tag = tagToAdd });
                        }
                    }
                    newSB.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");
                    gamesList.Add(newGame);
                }
                else
                {
                    newSB.AppendLine("Invalid Data");

                }
            }

            context.Games.AddRange(gamesList);
            context.SaveChanges();

            return newSB.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var inputUsers = JsonConvert.DeserializeObject<List<ImportUsersDTO>>(jsonString);
            var newSB = new StringBuilder();

            var users = new List<User>();

            foreach (var user in inputUsers)
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

                    users.Add(newUser);

                    newSB.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count()} cards");
                }
                else
                {
                    newSB.AppendLine("Invalid Data");
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return newSB.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchasesDTO[]), new XmlRootAttribute("Purchases"));
            StringReader rdr = new StringReader(xmlString);
            ImportPurchasesDTO[] purchasesDTO = (ImportPurchasesDTO[])serializer.Deserialize(rdr);

            var purchases = new List<Purchase>();
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

                    purchases.Add(newPurchase);

                    var username = context.Cards.Where(x => x.Number == purchase.Card).Select(x => x.User.Username).FirstOrDefault();
                    newSB.AppendLine($"Imported {purchase.Title} for {username}");
                }
                else
                {
                    newSB.AppendLine("Invalid Data");
                }
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

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