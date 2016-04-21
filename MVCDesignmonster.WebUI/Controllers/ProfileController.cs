using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.Logging;
using MVCDesignmonster.Models;
using MVCDesignmonster.Repository;

namespace MVCDesignmonster.WebUI.Controllers
{
    [LoggingFilter]
    public class ProfileController : Controller
    {
        // With ProfileRepository
        private IProfileRepository _repo;

        public ProfileController()
        {
            _repo = new ProfileRepository(new RepoDbContext());
        }

        public ProfileController(IProfileRepository profileRepo)
        {
            _repo = profileRepo;
        }

        //With generic repo
        //private IRepository<Profile> _repo;

        //public ProfileController()
        //{
        //    _repo = new SqlRepository<Profile>(new RepoDbContext());
        //}

        //public ProfileController(IRepository<Profile> profileRepo)
        //{
        //    _repo = profileRepo;
        //}

        // GET: Profile
        public ActionResult Index()
        {
            var test = _repo.GetProfile();
            return View(test);
        }

        //    #region TODO
        // GET: Profile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Profile profile = _repo.Search(n => n.ProfileId == id).SingleOrDefault();
            Profile profile = _repo.GetProfile();
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //    // GET: Profile/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Profile/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "ProfileId,Name,Email,PublicPresentationText,ShowPrivatePresentationText,PrivatePresentationText")] Profile profile)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _repo.Profile.Add(profile);
        //            _repo.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(profile);
        //    }

        //    // GET: Profile/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Profile profile = _repo.Profile.Find(id);
        //        if (profile == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(profile);
        //    }

        //    // POST: Profile/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "ProfileId,Name,Email,PublicPresentationText,ShowPrivatePresentationText,PrivatePresentationText")] Profile profile)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _repo.Entry(profile).State = EntityState.Modified;
        //            _repo.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(profile);
        //    }

        //    // GET: Profile/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Profile profile = _repo.Profile.Find(id);
        //        if (profile == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(profile);
        //    }

        //    // POST: Profile/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Profile profile = _repo.Profile.Find(id);
        //        _repo.Profile.Remove(profile);
        //        _repo.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
        //#endregion
    }
}
