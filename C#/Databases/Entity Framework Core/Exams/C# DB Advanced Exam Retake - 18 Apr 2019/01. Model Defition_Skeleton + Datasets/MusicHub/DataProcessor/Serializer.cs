namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDTOs;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(a => a.SongName)
                    .ThenBy(a => a.Writer)
                    .ToArray(),
                    AlbumPrice = x.Songs.Sum(a => a.Price).ToString("f2")

                }).ToArray()
                .OrderByDescending(x => x.AlbumPrice)
                .ToArray();

            var albumsJson = JsonConvert.SerializeObject(albums, Formatting.Indented);
            return albumsJson.ToString();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new ExportSongDTO
                {
                    AlbumProducer = x.Album.Producer.Name,
                    Performer = x.SongPerformers.Select(p => p.Performer.FirstName + " " + p.Performer.LastName).FirstOrDefault(),
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture)
                })
                .ToArray()
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToArray();

            StringBuilder newSB = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSongDTO[]), new XmlRootAttribute("Songs"));
            StringWriter rdr = new StringWriter(newSB);

            using (rdr)
            {
                serializer.Serialize(rdr, songs, GetXmlNamespaces());
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