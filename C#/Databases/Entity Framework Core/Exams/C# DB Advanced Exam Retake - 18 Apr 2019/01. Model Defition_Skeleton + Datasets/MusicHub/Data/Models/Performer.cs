using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        [Key]
        public int Id { get; set; }

        [Required,MinLength(3),MaxLength(20)]
        public string FirstName { get; set; }

        [Required,MinLength(3),MaxLength(20)]
        public string LastName { get; set; }

        [Range(18,70),Required]
        public int Age { get; set; }

        [Range(0,(double)decimal.MaxValue),Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
    }
}


