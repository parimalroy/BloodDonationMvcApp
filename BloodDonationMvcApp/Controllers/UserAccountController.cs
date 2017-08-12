using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodDonationMvcApp.Models;
using BloodDonationMvcApp.Context;

namespace BloodDonationMvcApp.Controllers
{
    public class UserAccountController : Controller
    {
        private BloodDonationDbContext db = new BloodDonationDbContext();

        // GET: /UserAccount/
        public ActionResult Index()
        {
            return View(db.aUserAccount.ToList());
        }

        // GET: /UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: /UserAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Name,Password")] UserAccount useraccount)
        {
            if (ModelState.IsValid)
            {
                db.aUserAccount.Add(useraccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(useraccount);
        }

        

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(BloodDonationDbContext db=new BloodDonationDbContext())
            {

                var usr = db.aUserAccount.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);

                if (usr!=null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Name"] = usr.Name.ToString();
                    return RedirectToAction("LoginHome");
                }
                else
                {
                    ModelState.AddModelError("","User name of password rong");
                }
            }
            return View();
        }
        public ActionResult LoginHome()
        {
            if (Session["Id"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: /UserAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Email,Password")] UserAccount useraccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(useraccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(useraccount);
        }

        // GET: /UserAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount useraccount = db.aUserAccount.Find(id);
            if (useraccount == null)
            {
                return HttpNotFound();
            }
            return View(useraccount);
        }

        // POST: /UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount useraccount = db.aUserAccount.Find(id);
            db.aUserAccount.Remove(useraccount);
            db.SaveChanges();
            return RedirectToAction("Index");
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
