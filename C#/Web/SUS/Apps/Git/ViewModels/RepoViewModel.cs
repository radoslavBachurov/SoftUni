using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels
{
    public class RepoViewModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string CreatedOn { get; set; }
        public int CommitsCount { get; set; }
        public string RepoId { get; set; }
    }
}
