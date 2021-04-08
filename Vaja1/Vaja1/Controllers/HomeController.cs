using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaja1.Models;

namespace Vaja1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TestModela()
        {
            Student s = new Student();
            s.StudentId = 123;
            s.StudentName = "Janez Novak";
            s.Age = 22;
            return View(s);
        }
        public ActionResult TestRazorja()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}