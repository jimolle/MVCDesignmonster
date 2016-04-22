﻿using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Service.SessionStats;
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
            return View(ActiveUserService.Instance.TrackedUsers);
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