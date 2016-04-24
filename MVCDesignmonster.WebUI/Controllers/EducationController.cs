using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.WebUI.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    public class EducationController : Controller
    {
        // With EducationRepository
        private IEducationRepository _repo;

        public EducationController()
        {
            _repo = new EducationRepository(new ProfileDbContext());
        }

        public EducationController(IEducationRepository educationRepo)
        {
            _repo = educationRepo;
        }

        // GET: Education
        public ActionResult Index()
        {
            return View(_repo.GetAllEducationsEvenPrivate());
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
