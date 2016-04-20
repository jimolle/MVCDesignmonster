using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDesignmonster.Models;
using MVCDesignmonster.Repository;

namespace MVCDesignmonster.WebUI.Controllers
{
    public class EducationController : Controller
    {
        // With EducationRepository
        private IEducationRepository _repo;

        public EducationController()
        {
            _repo = new EducationRepository(new RepoDbContext());
        }

        public EducationController(IEducationRepository educationRepo)
        {
            _repo = educationRepo;
        }

        // GET: Education
        public ActionResult Index()
        {
            // TODO Check if user is authorized
            if (User.IsInRole("Admin"))
            {
                // Can change stuff bla bla
            }
            return View(_repo.GetAllEducations());
        }

        // GET: Education/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = _repo.Search(n => n.EducationId == id).SingleOrDefault();
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: Education/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EducationId,Name,StartDate,EndDate,SchoolName,Description,Public")] Education education)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateEducation(education);
                _repo.Save();
                return RedirectToAction("Index");
            }

            return View(education);
        }

        // GET: Education/Edit/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = _repo.Search(n => n.EducationId == id).SingleOrDefault();
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Education/Edit/5
        [Authorize(Roles = "Admin, Owner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EducationId,Name,StartDate,EndDate,SchoolName,Description,Public")] Education education)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateEducation(education);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(education);
        }

        [Authorize(Roles = "Admin, Owner")]
        // GET: Education/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = _repo.Search(n => n.EducationId == id).SingleOrDefault();
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        [Authorize(Roles = "Admin, Owner")]
        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Education education = _repo.Search(n => n.EducationId == id).SingleOrDefault();
            _repo.DeleteEducation(id);
            _repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
