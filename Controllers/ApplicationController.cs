using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SeniorProject.Controllers
{
    public class ApplicationController : Controller
    {
        public void initializeUserSession(bool b)
        {
            //if (b)
            //{
            //    Session["Username"] = "notnull";
            //}
            //else
            //{
            //    Session["Username"] = null;
            //}
            

        }
        //populate user session in viewbag
        public void PopulateSession()
        {
            //if (Session["Username"] == null)
            //{
            //    ViewBag.UserSession = false;
            //}
            //else
            //{
            //    ViewBag.UserSession = Session["Username"].ToString();
            //}
        }
    }
}