using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class CourseManagementController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        //
        // GET: /CourseManagement/

        public ActionResult Index()
        {
            return View(db.CourseManagements.ToList());
        }

        //
        // GET: /CourseManagement/Details/5

        public ActionResult Details(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // GET: /CourseManagement/Create

        public ActionResult Create()
        {
            ViewBag.teachers = db.Teachers.ToList();
            ViewBag.class_ = db.Classes.ToList();
            ViewBag.courses = db.Courses.ToList();
            return View();
        }

        //
        // POST: /CourseManagement/Create

        [HttpPost]
        public ActionResult Create(CourseManagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.CourseManagements.Add(coursemanagements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemanagements);
        }

        //
        // GET: /CourseManagement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.teachers = db.Teachers.ToList();
            ViewBag.class_ = db.Classes.ToList();
            ViewBag.courses = db.Courses.ToList();
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /CourseManagement/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseManagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemanagements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemanagements);
        }

        //
        // GET: /CourseManagement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /CourseManagement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            db.CourseManagements.Remove(coursemanagements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}