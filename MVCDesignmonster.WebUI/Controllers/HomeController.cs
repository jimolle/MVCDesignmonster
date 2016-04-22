using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.Models;
using MVCDesignmonster.Repository;
using MVCDesignmonster.Singleton;
using MVCDesignmonster.WebUI.ViewModels;

namespace MVCDesignmonster.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // TODO repon i konstruktor


        public ActionResult Index()
        {
            var viewModel = new StartPageViewModel();
            using (var repo = new StartPageRepository(new ProfileDbContext()))
            {
                viewModel.WelcomeText = repo.GetStartpage().WelcomeText;
                viewModel.WelcomeTitle = repo.GetStartpage().WelcomeTitle;
            }

            return View(viewModel);
        }


        public ActionResult Debug()
        {
            return View(SessionStats.Instance.TrackedUsers);
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