using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProject.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {

            //Session["Username"] = "JimBob";

            //if (Session["Username"] == null)
            //{ 
            //    initializeUserSession(false);
            //} else
            //{
            //    initializeUserSession(true);
            //}

            ViewBag.HW = "hello world!";
            //PopulateSession();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            PopulateSession();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}