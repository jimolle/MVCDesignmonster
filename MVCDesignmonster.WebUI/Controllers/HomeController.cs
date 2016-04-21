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
        public ActionResult RenderMenu()
        {
            var menuToRender = "_menuAnonymous";
            if (User.IsInRole("Admin"))
            {
                menuToRender = "_menuAdmin";
            }
            else if (User.IsInRole("Owner"))
            {
                menuToRender = "_menuOwner";
            }
            else if (User.IsInRole("User"))
            {
                menuToRender = "_menuUser";
            }

            return PartialView(menuToRender);
        }

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

        public ActionResult SessionStatsPage()
        {
            //var singleton1 = SessionStats.Instance;
            //var singleton2 = SessionStats.Instance;
            //Debug.WriteLine(singleton1.GetHashCode());
            //Debug.WriteLine(singleton2.GetHashCode());

            var loggingService = new LogRepository(new ProfileDbContext());
            var statLog = loggingService.GetLast100LogPosts().ToList();

            var result = new SessionStatsViewModel()
            {
                SessionStats = SessionStats.Instance.GetSessionStats(),
                StatLogs = statLog
            };

            ViewBag.Message = "Session stats.";
            return View(result);
        }

        public ActionResult FileUpload()
        {
            ViewBag.Message = "Try some image uploading.";

            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/img_profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("SUCCESS", "no controller");
        }
    }
}