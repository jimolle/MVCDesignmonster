using System.Diagnostics;
using System.Web.Mvc;
using MVCDesignmonster.Logging;
using MVCDesignmonster.Singleton;
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
            var singleton1 = SessionStats.Instance;
            var singleton2 = SessionStats.Instance;


            Debug.WriteLine(singleton1.GetHashCode());
            Debug.WriteLine(singleton2.GetHashCode());

            Debug.WriteLine(singleton2.DoSomeStats(10));
            Debug.WriteLine(singleton1.DoSomeStats(10));

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