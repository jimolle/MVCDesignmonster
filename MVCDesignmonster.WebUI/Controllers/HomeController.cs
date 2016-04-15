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
        private TestViewModel _testViewModel;

        public HomeController()
        {
            _testViewModel = new TestViewModel()
            {
                Text = null,
                MaxWords = 3 //OBS! HÅRDKODAT även i TestViewModel...
            };
        }

        public ActionResult Index()
        {
            return View(_testViewModel);
        }

        [HttpPost]
        public ActionResult Index(TestViewModel inputTestViewModel)
        {
            if (ModelState.IsValid)
            {
                _testViewModel.Text = inputTestViewModel.Text;
                return View(_testViewModel);
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