using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.BLLs.Classes
{
    public class ClassRepository:IClassRepository
    {
        protected CourseManagerEntities db = new CourseManagerEntities();
        public List<CourseDetail> GetClassCourse(int id)
        {
            /*
            select c.Name, cr.Name, t.Name
            from CourseManagements as cm
            join Classes as c on cm.ClassId = c.Id 
            join Courses as cr on cm.CourseId = cr.Id
            join Teachers as t on cm.TeacherId = t.Id
            where ClassId=1
             */

            var query =
                from cm in db.CourseManagements
                join c in db.Classes
                    on cm.ClassId equals c.Id
                join cr in db.Courses
                    on cm.CourseId equals cr.Id
                join t in db.Teachers
                    on cm.TeacherId equals t.Id
                where cm.ClassId == id
                select new CourseDetail
                {
                    ClassName = c.Name,
                    CourseName = cr.Name,
                    TeacherName = t.Name
                };
            return query.ToList();
        }
    }
}