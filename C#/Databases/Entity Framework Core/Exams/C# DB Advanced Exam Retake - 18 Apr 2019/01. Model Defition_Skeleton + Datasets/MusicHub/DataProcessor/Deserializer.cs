namespace MusicHub.DataProcessor
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
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writers = JsonConvert.DeserializeObject<List<ImportWriterDTO>>(jsonString);

            var newSB = new StringBuilder();
            List<Writer> sortedWriters = new List<Writer>();
            foreach (var writer in writers)
            {
                if (IsValid(writer))
                {
                    var newWriter = new Writer()
                    {
                        Name = writer.Name,
                        Pseudonym = writer.Pseudonym
                    };
                    sortedWriters.Add(newWriter);
                    newSB.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
                }
                else
                {
                    newSB.AppendLine(ErrorMessage);
                }

            }

            context.Writers.AddRange(sortedWriters);
            context.SaveChanges();

            return newSB.ToString().Trim();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersAlbums = JsonConvert.DeserializeObject<List<ImportProducerAlbumDTO>>(jsonString);

            var newSB = new StringBuilder();
            List<Producer> sortedProducers = new List<Producer>();

            foreach (var producer in producersAlbums)
            {
                var newProducer = new Producer();

                if (IsValid(producer) && producer.Albums.TrueForAll(x => IsValid(x)))
                {
                    newProducer.Name = producer.Name;
                    newProducer.PhoneNumber = producer.PhoneNumber;
                    newProducer.Pseudonym = producer.Pseudonym;
                    newProducer.Albums = producer.Albums
                        .Select(x => new Album
                        {
                            Name = x.Name,
                            ReleaseDate = DateTime.ParseExact(x.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        }).ToList();

                    sortedProducers.Add(newProducer);

                    if (newProducer.PhoneNumber == null)
                    {
                        newSB.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, newProducer.Name, newProducer.Albums.Count()));
                    }
                    else
                    {
                        newSB.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, newProducer.Name, newProducer.PhoneNumber, newProducer.Albums.Count()));
                    }

                }
                else
                {
                    newSB.AppendLine(ErrorMessage);
                }
            }

            context.Producers.AddRange(sortedProducers);
            context.SaveChanges();

            return newSB.ToString().Trim();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var albumIDs = context.Albums.Select(x => x.Id).ToArray();
            var writerIDs = context.Writers.Select(x => x.Id).ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportSongDTO[]), new XmlRootAttribute("Songs"));
            StringReader rdr = new StringReader(xmlString);
            ImportSongDTO[] songsDTO = (ImportSongDTO[])serializer.Deserialize(rdr);

            List<Song> songs = new List<Song>();
            var newSB = new StringBuilder();
            Genre typeGenre = new Genre();
            foreach (var song in songsDTO)
            {
                if (IsValid(song) &&
                    albumIDs.Any(x => x == song.AlbumId) &&
                    writerIDs.Any(x => x == song.WriterId &&
                    Enum.TryParse(song.Genre, true, out typeGenre)))
                {
                    Song newSong = new Song()
                    {
                        Name = song.Name,
                        Genre = typeGenre,
                        Price = song.Price,
                        AlbumId = song.AlbumId,
                        WriterId = song.WriterId,
                        CreatedOn = DateTime.ParseExact(song.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Duration = TimeSpan.ParseExact(song.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative),

                    };

                    songs.Add(newSong);
                    newSB.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }
                else
                {
                    newSB.AppendLine(ErrorMessage);
                }
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return newSB.ToString().Trim();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var songIDs = context.Songs.Select(x => x.Id).ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportSongPerformerDTO[]), new XmlRootAttribute("Performers"));
            StringReader rdr = new StringReader(xmlString);
            ImportSongPerformerDTO[] songsPerformerDTO = (ImportSongPerformerDTO[])serializer.Deserialize(rdr);

            List<Performer> performers = new List<Performer>();
            List<SongPerformer> songsPerformers = new List<SongPerformer>();
            var newSB = new StringBuilder();

            foreach (var performer in songsPerformerDTO)
            {
                if (IsValid(performer) && performer.Songs.Select(x => x.Id).All(x => songIDs.Contains(x)))
                {
                    var newPerformer = new Performer()
                    {
                        Age = performer.Age,
                        FirstName = performer.FirstName,
                        LastName = performer.LastName,
                        NetWorth = performer.NetWorth,
                    };
                    performers.Add(newPerformer);

                    foreach (var song in performer.Songs.Select(x => x.Id).Distinct())
                    {
                        var songPerformer = new SongPerformer()
                        {
                            Performer = newPerformer,
                            SongId = song
                        };

                        songsPerformers.Add(songPerformer);
                    }

                    newSB.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.Songs.Count()));
                }
                else
                {
                    newSB.AppendLine(ErrorMessage);
                }
            }

            context.Performers.AddRange(performers);
            context.SongsPerformers.AddRange(songsPerformers);
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