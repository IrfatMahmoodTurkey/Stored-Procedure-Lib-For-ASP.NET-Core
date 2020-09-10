using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlProcedureWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public List<TakenCourse> TakenCourses { get; set; }
    }
}
