using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.BLLs.Classes
{
    public interface IClassRepository
    {
        List<CourseDetail> GetClassCourse(int id);
    }
}
