using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{
    public partial class Students
    {
        public string ClassName 
        {
            get {

                CourseManagerEntities db = new CourseManagerEntities();
                var class_ = db.Classes.Where(t => t.Id == ClassId).FirstOrDefault();
                if (class_ == null) {
                    return "";
                }
                return class_.Name;
            }
        
        }
    }
}