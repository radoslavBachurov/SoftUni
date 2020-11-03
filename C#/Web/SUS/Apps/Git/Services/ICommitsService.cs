using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        CommitRepoViewModel FindRepo(string repoId);

        void CreateCommit(string id, string userId, string description);

        IEnumerable<CommitViewModel> GetAll(string userId);

        void DeleteCommit(string id);
    }
}
