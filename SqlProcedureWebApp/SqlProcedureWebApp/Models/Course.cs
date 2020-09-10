using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlProcedureWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
        public List<TakenCourse> TakenCourses { get; set; }
    }
}