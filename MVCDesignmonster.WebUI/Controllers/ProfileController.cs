using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.Models;
using MVCDesignmonster.Repository;
using MVCDesignmonster.Singleton;
using MVCDesignmonster.WebUI.ViewModels;

namespace MVCDesignmonster.WebUI.Controllers
{
    [Route("Profil/{action}")]
    public class ProfileController : Controller
    {
        // With ProfileRepository
        private IProfileRepository _repoProfile;
        private IEducationRepository _repoEducation;
        private IEmployerRepository _repoEmployer;

        public ProfileController()
        {
            _repoProfile = new ProfileRepository(new ProfileDbContext());
            _repoEducation = new EducationRepository(new ProfileDbContext());
            _repoEmployer = new EmployerRepository(new ProfileDbContext());

        }

        public ProfileController(IProfileRepository profileRepo, IEducationRepository educationRepo, IEmployerRepository employerRepo)
        {
            _repoProfile = profileRepo;
            _repoEducation = educationRepo;
            _repoEmployer = employerRepo;
        }


        // GET: Profile
        [Route("Profil")]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("PrivateProfile");
            else
                return RedirectToAction("PublicProfile");
        }

        // GET: Profile/PublicProfile
        public ActionResult PublicProfile()
        {
            if (_repoProfile.GetProfile().ShowProfileForAnonymous == false)
                return RedirectToAction("Login", "Account");

            // Getting public profile
            var viewModel = new ProfileViewModel()
            {
                Profile = _repoProfile.GetProfile(),
                Educations = _repoEducation.GetPublicEducations().Where(n => n.Public),
                Employers = _repoEmployer.GetPublicEmployers().Where(n => n.Public)
            };

            return View(viewModel);
        }

        // GET: Profile/PrivateProfile
        [Authorize]
        public ActionResult PrivateProfile()
        {
            // Getting full profile
            var viewModel = new ProfileViewModel()
            {
                Profile = _repoProfile.GetProfile(),
                Educations = _repoEducation.GetAllEducationsEvenPrivate(),
                Employers = _repoEmployer.GetAllEmployersEvenPrivate()
            };

            return View(viewModel);
        }

       
        // GET: Profile/Edit/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Edit()
        {
            Profile profile = _repoProfile.GetProfile();
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Edit([Bind(Include = "ProfileId, Name,Email,PublicPresentationText,ShowProfileForAnonymous,PrivatePresentationText")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                _repoProfile.UpdateProfile(profile);
                _repoProfile.Save();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        public ActionResult PicUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult PicUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 2000000)
                    throw new Exception("för stor fil MAX 2 mb");

                var pic = "";
                //string pic = System.IO.Path.GetFileName(file.FileName);
                var fileType = file.ContentType;
                switch (fileType)
                {
                    case "image/jpeg":
                        pic = "profilBild.jpg";
                        break;
                    case "image/png":
                        pic = "profilBild.png";
                        break;
                    default:
                        throw new Exception("fel filtyp");
                }


                var path = System.IO.Path.Combine(
                                       Server.MapPath("/Content/img_profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database 
                var profile = _repoProfile.GetProfile();
                profile.ImagePath = pic;
                _repoProfile.Save();


                // or you can send image directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Owner")]
        public ActionResult SessionStatsPage()
        {
            using (var loggingService = new LogRepository(new ProfileDbContext()))
            {
                var statLog = loggingService.GetLast100LogPosts().ToList();
                
                var result = new SessionStatsViewModel()
                {
                    SessionStats = SessionStats.Instance.GetSessionStats(),
                    StatLogs = statLog
                };

                return View(result);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repoProfile.Dispose();
            _repoEducation.Dispose();
            _repoEmployer.Dispose();
            base.Dispose(disposing);
        }


    }
}
