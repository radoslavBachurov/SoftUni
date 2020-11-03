using Git.DTO;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<RepoViewModel> GetAll();

        void AddRepo(AddRepoInputModel model,string id);
    }
}
