using Git.Data;
using Git.DTO;
using Git.ViewModels;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;
        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<RepoViewModel> GetAll()
        {
            var repositories = this.db.Repositories.Where(x => x.IsPublic).Select(x => new RepoViewModel
            {
                Name = x.Name,
                CommitsCount = x.Commits.Count,
                CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd HH:mm",
                                CultureInfo.InvariantCulture),
                Owner = x.Owner.Username,
                RepoId = x.Id
            }).ToList();

            return repositories;
        }

        public void AddRepo(AddRepoInputModel model,string id)
        {
            var repo = new Repository
            {
                CreatedOn = DateTime.Now,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                OwnerId = id,
                Name = model.Name
            };
            this.db.Repositories.Add(repo);
            this.db.SaveChanges();
        }
    }
}
