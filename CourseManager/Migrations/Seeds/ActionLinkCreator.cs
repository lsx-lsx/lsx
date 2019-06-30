using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Migrations.Seeds
{
    public class ActionLinkCreator
    {
        private readonly CourseManager.Models.CourseManagerEntities _context;
        public ActionLinkCreator(CourseManager.Models.CourseManagerEntities context)
        {
            _context = context;
        }

        public void Seed()
        {
            var iniitialActionLinks = new List<ActionLinks>
            {
                new ActionLinks
                {
                    Name = "主页",
                    Controller = "Home",
                    Action = "Index",
                    order = 1
                },
                new ActionLinks
                {
                    Name = "关于",
                    Controller = "Home",
                    Action = "About",
                    order = 2
                },
                new ActionLinks
                {
                    Name = "联系方式",
                    Controller = "Home",
                    Action = "Contact",
                    order = 3
                }
            };

            foreach (var action in iniitialActionLinks)
            { 
                if (_context.ActionLinks.Any(r => r.Name == action.Name))
                {
                    continue;
                }
                _context.ActionLinks.Add(action);
            }
            _context.SaveChanges();
        }
    }
}