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
    public class EmployerController : Controller
    {
        // With EmployerRepo
        private IEmployerRepository _repo;

        public EmployerController()
        {
            _repo = new EmployerRepository(new RepoDbContext());
        }

        public EmployerController(IEmployerRepository employerRepo)
        {
            _repo = employerRepo;
        }

        // GET: Employer
        public ActionResult Index()
        {
            return View(_repo.GetAllEmployersEvenPrivate());
        }

        // GET: Employer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = _repo.Search(n => n.EmployerId == id).SingleOrDefault();
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // GET: Employer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployerId,Name,StartDate,EndDate,Public")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateEmployer(employer);
                _repo.Save();
                return RedirectToAction("Index");
            }

            return View(employer);
        }

        // GET: Employer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = _repo.Search(n => n.EmployerId == id).SingleOrDefault();
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployerId,Name,StartDate,EndDate,Public")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateEmployer(employer);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(employer);
        }

        // GET: Employer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = _repo.Search(n => n.EmployerId == id).SingleOrDefault();
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employer employer = _repo.Search(n => n.EmployerId == id).SingleOrDefault();
            _repo.DeleteEmployer(id);
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
