using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        public ActionResult SessionStatsPage()
        {
            var singleton1 = SessionStats.Instance;
            var singleton2 = SessionStats.Instance;


            Debug.WriteLine(singleton1.GetHashCode());
            Debug.WriteLine(singleton2.GetHashCode());

            Debug.WriteLine(singleton2.DoSomeStats(10));
            Debug.WriteLine(singleton1.DoSomeStats(10));

            // SESSIONSTATS
            var totalUsers = (int)HttpContext.Application["OnlineUsers"];


            //TODO Detta funkade ju inte...
            var onlineUsers = (from a in Membership.GetAllUsers().Cast<MembershipUser>().ToList()
                               where a.IsOnline
                               select a.UserName).ToList();

            var result = new SessionStatsViewModel()
            {
                LoggedInUsers = onlineUsers,
                TotalSessions = totalUsers,
                LoggedInSessions = onlineUsers.Count,
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