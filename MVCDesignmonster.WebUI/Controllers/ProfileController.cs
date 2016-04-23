using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Service.SessionStats;
using MVCDesignmonster.WebUI.ViewModels;

namespace MVCDesignmonster.WebUI.Controllers
{
    [Route("Profil/{action}")]
    public class ProfileController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProfileController() 
            : this (new UnitOfWork())
        { }

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //// With ProfileRepository
        //private readonly IProfileRepository _repoProfile;
        //private readonly IEducationRepository _repoEducation;
        //private readonly IEmployerRepository _repoEmployer;

        //public ProfileController()
        //    : this (null, null, null)
        //{
        //    //_repoProfile = new ProfileRepository();
        //    //_repoEducation = new EducationRepository();
        //    //_repoEmployer = new EmployerRepository();

        //}

        //public ProfileController(IProfileRepository profileRepo, IEducationRepository educationRepo, IEmployerRepository employerRepo)
        //{
        //    _repoProfile = profileRepo ?? new ProfileRepository();
        //    _repoEducation = educationRepo ?? new EducationRepository();
        //    _repoEmployer = employerRepo ?? new EmployerRepository();
        //}


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
            if (_unitOfWork.ProfileRepository.GetProfile().ShowProfileForAnonymous == false)
                return RedirectToAction("Login", "Account");

            // Getting public profile
            var viewModel = new ProfileViewModel()
            {
                Profile = _unitOfWork.ProfileRepository.GetProfile(),
                Educations = _unitOfWork.EducationRepository.GetPublicEducations().Where(n => n.Public),
                Employers = _unitOfWork.EmployerRepository.GetPublicEmployers().Where(n => n.Public)
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
                Profile = _unitOfWork.ProfileRepository.GetProfile(),
                Educations = _unitOfWork.EducationRepository.GetAllEducationsEvenPrivate(),
                Employers = _unitOfWork.EmployerRepository.GetAllEmployersEvenPrivate()
            };

            return View(viewModel);
        }

       
        // GET: Profile/Edit/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Edit()
        {
            Profile profile = _unitOfWork.ProfileRepository.GetProfile();
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
                _unitOfWork.ProfileRepository.UpdateProfile(profile);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        [Authorize(Roles = "Admin, Owner")]
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
                    ModelState.AddModelError("", "Max 2 mb!");

                var pic = "";
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
                        ModelState.AddModelError("", "Endast .jpg- och .png-filer stödjs!");
                        break;
                }

                if (!ModelState.IsValid)
                    return View();


                var path = System.IO.Path.Combine(
                                       Server.MapPath("/Content/img_profile"), pic);

                file.SaveAs(path);

                // save the image path path to the database 
                var profile = _unitOfWork.ProfileRepository.GetProfile();
                profile.ImagePath = pic;
                _unitOfWork.Save();


                // or you can send image directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Owner")]
        public ActionResult SessionStatsPage()
        {
            using (var loggingService = new LogRepository())
            {
                var statLog = loggingService.GetLast100LogPosts().ToList();
                
                var result = new SessionStatsViewModel()
                {
                    SessionStats = ActiveUserService.Instance.GetSessionStats(),
                    StatLogs = statLog
                };

                return View(result);
            }
        }

        [Authorize(Roles = "Admin, Owner")]
        public ActionResult DeletePic()
        {
            // Delete ImagePath
            var profile = _unitOfWork.ProfileRepository.GetProfile();
            var path = profile.ImagePath;
            profile.ImagePath = null;
            _unitOfWork.Save();

            // Delete pic
            // TODO Den tar bara bort aktiv bild, om det fanns två sparas ju den andra...
            var fullPath = System.IO.Path.Combine(
                       Server.MapPath("/Content/img_profile"), path);
            System.IO.File.Delete(fullPath);


            return RedirectToAction("PicUpload");
        }

        public ActionResult PicExists()
        {
            var viewModel = new PicUploadViewModel();
            if (_unitOfWork.ProfileRepository.GetProfile().ImagePath == null)
            {
                viewModel.ImagePath = null;
            }
            else
            {
                viewModel.ImagePath = _unitOfWork.ProfileRepository.GetProfile().ImagePath;
            }

            return PartialView(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            //_repoProfile.Dispose();
            //_repoEducation.Dispose();
            //_repoEmployer.Dispose();
            base.Dispose(disposing);
        }

    }
}
