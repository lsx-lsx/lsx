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
    public class CourseController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        public ActionResult Create(Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
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