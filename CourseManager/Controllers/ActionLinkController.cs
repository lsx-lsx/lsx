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
    public class ActionLinkController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        //
        // GET: /ActionLink/

        public ActionResult Index()
        {
            return View(db.ActionLinks.ToList());
        }

        //
        // GET: /ActionLink/Details/5

        public ActionResult Details(int id = 0)
        {
            ActionLinks actionlinks = db.ActionLinks.Find(id);
            if (actionlinks == null)
            {
                return HttpNotFound();
            }
            return View(actionlinks);
        }

        //
        // GET: /ActionLink/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ActionLink/Create

        [HttpPost]
        public ActionResult Create(ActionLinks actionlinks)
        {
            if (ModelState.IsValid)
            {
                db.ActionLinks.Add(actionlinks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionlinks);
        }

        //
        // GET: /ActionLink/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ActionLinks actionlinks = db.ActionLinks.Find(id);
            if (actionlinks == null)
            {
                return HttpNotFound();
            }
            return View(actionlinks);
        }

        //
        // POST: /ActionLink/Edit/5

        [HttpPost]
        public ActionResult Edit(ActionLinks actionlinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionlinks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionlinks);
        }

        //
        // GET: /ActionLink/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ActionLinks actionlinks = db.ActionLinks.Find(id);
            if (actionlinks == null)
            {
                return HttpNotFound();
            }
            return View(actionlinks);
        }

        //
        // POST: /ActionLink/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionLinks actionlinks = db.ActionLinks.Find(id);
            db.ActionLinks.Remove(actionlinks);
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