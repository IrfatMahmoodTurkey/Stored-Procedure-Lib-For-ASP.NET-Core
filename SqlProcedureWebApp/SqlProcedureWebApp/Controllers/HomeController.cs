using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlProcedureWebApp.Models;
using SqlProcedureWebApp.Models.Context;
using SqlProcedureWebApp.Models.ViewModels;
using SqlStoredProcedureLib;

namespace SqlProcedureWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string connectionString = ApplicationDbContext.ConnectionString;

            List<ProcedureParams> paramsList = new List<ProcedureParams>();
            paramsList.Add(new ProcedureParams(){ParamName = "StudentId", Param = "145488" });
            List<string> lists = CallStoredProcedure.CallAndGet(connectionString, "dbo.StudentCourseProcedure", paramsList); // data is returning as list of json string
            List<StudentCoursesViewModel> dataLists = new List<StudentCoursesViewModel>();
            foreach (string jsonString in lists)
            {
                dataLists.Add(JsonConvert.DeserializeObject<StudentCoursesViewModel>(jsonString));
            }

            ViewBag.StudentCourses = dataLists;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
