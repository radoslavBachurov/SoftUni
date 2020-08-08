namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
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
            throw new NotImplementedException();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}