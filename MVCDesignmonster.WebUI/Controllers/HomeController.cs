using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.BusinessObjects.Repository.Generic;
using MVCDesignmonster.Service.SessionStats;
using MVCDesignmonster.WebUI.ViewModels;

namespace MVCDesignmonster.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IStartpageRepository _repo;

        public HomeController()
        {
            _repo = new StartPageRepository(new ProfileDbContext());
        }

        public HomeController(IStartpageRepository repo)
        {
            _repo = repo;
        }


        public ActionResult Index()
        {
            var viewModel = new StartPageViewModel()
            {
                WelcomeText = _repo.GetStartpage().WelcomeText,
                WelcomeTitle = _repo.GetStartpage().WelcomeTitle,
            };

            return View(viewModel);
        }


        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }

        // NOT USED
        //public ActionResult RenderMenu()
        //{
        //    var menuToRender = "_menuAnonymous";
        //    if (User.IsInRole("Admin"))
        //    {
        //        menuToRender = "_menuAdmin";
        //    }
        //    else if (User.IsInRole("Owner"))
        //    {
        //        menuToRender = "_menuOwner";
        //    }
        //    else if (User.IsInRole("User"))
        //    {
        //        menuToRender = "_menuUser";
        //    }

        //    return PartialView(menuToRender);
        //}
    }
}