using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCDesignmonster.Models;
using MVCDesignmonster.Repository;
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

       

        protected override void Dispose(bool disposing)
        {
            _repoProfile.Dispose();
            _repoEducation.Dispose();
            _repoEmployer.Dispose();
            base.Dispose(disposing);
        }

    }
}
