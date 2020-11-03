using Git.DTO;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repService)
        {
            this.repositoriesService = repService;
        }
        public HttpResponse All()
        {
           
            var repoViewModel = this.repositoriesService.GetAll();
            return this.View(repoViewModel);
        }

        public HttpResponse Create(string repoId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(AddRepoInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Name should be between 3 and 10 characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.RepositoryType))
            {
                return this.Error("RepositoryType is required .");
            }
            var userId = this.GetUserId();
            this.repositoriesService.AddRepo(model, userId);
            
            return this.Redirect("/Repositories/All");
        }


    }
}
