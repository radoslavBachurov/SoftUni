﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Data
{
    public class Repository
    {
        public Repository()
        {
            this.Commits = new HashSet<Commit>();
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required,MinLength(3),MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}



