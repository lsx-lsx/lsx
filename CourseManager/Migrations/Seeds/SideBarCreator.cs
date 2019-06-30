using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Migrations.Seeds
{
    public class SideBarCreator
    {
        private readonly CourseManager.Models.CourseManagerEntities _context;
        public SideBarCreator(CourseManager.Models.CourseManagerEntities context)
        {
            _context = context;
        }

        public void Seed()
        {
            var iniitialSideBars = new List<SideBars>
            {
                new SideBars
                {
                    Name = "班级管理",
                    Controller = "Class",
                    Action = "Index",
                    order = 1
                },
                new SideBars
                {
                    Name = "老师管理",
                    Controller = "Teacher",
                    Action = "Index",
                    order = 2
                },
                new SideBars
                {
                    Name = "学生管理",
                    Controller = "Student",
                    Action = "Index",
                    order = 3
                },
                new SideBars
                {
                    Name = "课程科目管理",
                    Controller = "Course",
                    Action = "Index",
                    order = 4
                },
                new SideBars
                {
                    Name = "课程安排",
                    Controller = "CourseManagement",
                    Action = "Index",
                    order = 5
                },
                new SideBars
                {
                    Name = "左侧导航栏管理",
                    Controller = "SideBar",
                    Action = "Index",
                    order = 6
                },
                new SideBars
                {
                    Name = "顶部导航栏管理",
                    Controller = "ActionLink",
                    Action = "Index",
                    order = 7
                }
            };

            foreach (var sidebar in iniitialSideBars)
            {
                if (_context.SideBars.Any(r => r.Name == sidebar.Name))
                {
                    continue;
                }
                _context.SideBars.Add(sidebar);
            }
            _context.SaveChanges();
        }
    }


}