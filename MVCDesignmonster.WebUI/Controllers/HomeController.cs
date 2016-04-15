using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.Logging;
using MVCDesignmonster.WebUI.ViewModels;

namespace MVCDesignmonster.WebUI.Controllers
{
    [LoggingFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestViewModel inputTestViewModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SuccessText = inputTestViewModel.Text;
                return View();
            }

            return View(inputTestViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}