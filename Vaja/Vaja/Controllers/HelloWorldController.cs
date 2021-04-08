using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vaja.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }
        // HelloWorld/Pozdravljen?ime=Ben&num=2
        public ActionResult Pozdravljen(string ime, int num=1)
        {
            ViewBag.Message = "Pozdravljen " + ime;
            ViewBag.Num = num;
            return View();
        }
        public ActionResult Vaja(int id)
        {
            ViewBag.Num = id;
            return View();
        }
    }
}