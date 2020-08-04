using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongPerformerDTO
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Range(18, 70), Required]
        public int Age { get; set; }

        [Range(0, (double)decimal.MaxValue), Required]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public SongsIdDTO[] Songs { get; set; }
    }

    [XmlType("Song")]
    public class SongsIdDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
