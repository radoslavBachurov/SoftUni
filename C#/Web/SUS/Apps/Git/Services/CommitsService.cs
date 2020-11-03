using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;
        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public CommitRepoViewModel FindRepo(string repoId)
        {
            var repo = this.db.Repositories.Where(x => x.Id == repoId).Select(x => new CommitRepoViewModel
            {
                Name = x.Name,
                Id = x.Id
            }).FirstOrDefault();

            return repo;
        }

        public void CreateCommit(string id, string userId, string description)
        {
            var newCommit = new Commit()
            {
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                Description = description,
                RepositoryId = id
            };

            this.db.Commits.Add(newCommit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            var commits = this.db.Commits.Where(x => x.CreatorId == userId).Select(x => new CommitViewModel
            {
                CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd HH:mm",
                                CultureInfo.InvariantCulture),
                Description = x.Description,
                Repository = x.Repository.Name,
                Id = x.Id
            }).ToList();

            return commits;
        }

        void ICommitsService.DeleteCommit(string id)
        {
            var commit = this.db.Commits.Where(x => x.Id == id).FirstOrDefault();

            if (commit != null)
            {
                this.db.Commits.Remove(commit);
                this.db.SaveChanges();
            }
        }
    }
}

