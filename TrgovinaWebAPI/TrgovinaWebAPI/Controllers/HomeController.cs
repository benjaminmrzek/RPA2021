﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrgovinaWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Admin() //dodano
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin" }); //Pazimo da je isti kot na WebApiConfig.cs
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();
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