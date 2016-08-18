using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeniorProject;
using SeniorProject.DAL;
using SeniorProject.Models;
using System.Data.Entity.Core.Objects;

namespace SeniorProject.Controllers
{

    public class UserController : ApplicationController
    {
        public LoseContext db = new LoseContext();


        public void RefreshAll()
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
        public ActionResult Dashboard()
        {

            //Gather information for calculations
            String UserName = Session["Username"].ToString();

            var Weight = (from u in db.User
                          where u.Name == UserName
                          select u.Weight).FirstOrDefault();

            var Height = (from u in db.User
                          where u.Name == UserName
                          select u.Height).FirstOrDefault();

            var Age = (from u in db.User
                          where u.Name == UserName
                          select u.Age).FirstOrDefault();

            var IsMale = (from u in db.User
                       where u.Name == UserName
                       select u.IsMale).FirstOrDefault();

            double BMR = 0;

            //calculate BMI
            var BMI = (Weight * 703) / Math.Pow(Height, 2);
            ViewBag.BMI = Math.Round(BMI, 1);

            //Calculate BMR
            if (IsMale)
            {
                 BMR = 66 + (6.23 * Weight) + (12.7 * Height) - (6.8 * int.Parse(Age));
                ViewBag.BMR = Math.Round(BMR, 0);
            } else
            {
                 BMR = 655 + (4.35 * Weight) + (4.7 * Height) - (4.7 * int.Parse(Age));
                ViewBag.BMR = Math.Round(BMR, 0);
            }

            //populate BMR table
            var Half = BMR - 250;
            var One = BMR - 500;
            var Two = BMR - 1000;
            ViewBag.Half = Half;
            ViewBag.One = One;
            ViewBag.Two = Two;

            return View();
        }

        public ActionResult WeighIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult WeighIn(double WI)
        {

            String UserName = Session["Username"].ToString();

            //add data to WeighIn table
            //var context = new LoseContext();
            //var w = new UserModels
            //{
            //    Weight = WI,
            //};
            //db.User.Add(w);
            //db.SaveChanges();
          
            //update value for user weight 
            
                var result = db.User.SingleOrDefault(u => u.Name == UserName);
                if (result != null)
                {
                    result.Weight = WI;
                    db.SaveChanges();
                }




            //go home
            return RedirectToAction("Dashboard", User);
        }
        [HttpPost]
        public ActionResult Login(string n, string p)
        {

            var account = (from u in db.User
                           where u.Name == n && u.Password == p
                           select u.Name).FirstOrDefault();

            Session["Username"] = account;
            ViewBag.UserSession = account;

            return RedirectToAction("Dashboard", User);
        }

        public ActionResult Logout()
        {
            Session["Username"] = null;

            return View("../Home/Index");
        }



        //below results not user facing

        //// GET: User
        //public ActionResult Index()
        //{
        //    return View(db.User.ToList());
        //}

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModels user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        //GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Name,Password, Age,IsMale,Height,Weight,Goal")] UserModels user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                Session["Username"] = user.Name;
                return RedirectToAction("../User/Dashboard");
            }


            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModels user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,IsMale,Height,GoalWeight,Avatar,DOB")] UserModels user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModels user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserModels user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("../Home/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
