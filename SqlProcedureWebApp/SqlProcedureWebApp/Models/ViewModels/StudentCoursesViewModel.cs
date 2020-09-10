using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlProcedureWebApp.Models.ViewModels
{
    // property as same case as procedure return column name
    public class StudentCoursesViewModel
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
    }
}
