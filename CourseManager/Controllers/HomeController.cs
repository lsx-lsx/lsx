using CourseManager.Filters;
using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManager.Controllers
{
    [RequireAuthentication]
    public class HomeController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "修改此模板以快速启动你的 ASP.NET MVC 应用程序。";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的应用程序说明页。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的联系方式页。";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Navbar()
        {
            var site = new WebsiteInfo();
            var actionlinks = db.ActionLinks.ToList();
            var a = actionlinks.OrderBy(c => c.order);
            ViewBag.Site = site;
            return PartialView("~/Views/Shared/Navbar.cshtml",a);
        }

        [ChildActionOnly]
        public ActionResult SideBar()
        {
            var sidebars = db.SideBars.ToList();
            var a = sidebars.OrderBy(c => c.order);
            ViewBag.SideBars = sidebars;
            return PartialView("~/Views/Shared/SideBar.cshtml");
        }
    }
}
