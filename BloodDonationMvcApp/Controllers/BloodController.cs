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
    public class BloodController : Controller
    {
        private BloodDonationDbContext db = new BloodDonationDbContext();

        // GET: /Blood/
        public ActionResult Index()
        {
            return View(db.aBlood.ToList());
        }

        // GET: /Blood/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroups bloodgroups = db.aBlood.Find(id);
            if (bloodgroups == null)
            {
                return HttpNotFound();
            }
            return View(bloodgroups);
        }

        // GET: /Blood/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Blood/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,BloodName")] BloodGroups bloodgroups)
        {
            if (ModelState.IsValid)
            {
                db.aBlood.Add(bloodgroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodgroups);
        }

        // GET: /Blood/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroups bloodgroups = db.aBlood.Find(id);
            if (bloodgroups == null)
            {
                return HttpNotFound();
            }
            return View(bloodgroups);
        }

        // POST: /Blood/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,BloodName")] BloodGroups bloodgroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodgroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodgroups);
        }

        // GET: /Blood/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroups bloodgroups = db.aBlood.Find(id);
            if (bloodgroups == null)
            {
                return HttpNotFound();
            }
            return View(bloodgroups);
        }

        // POST: /Blood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodGroups bloodgroups = db.aBlood.Find(id);
            db.aBlood.Remove(bloodgroups);
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


        public JsonResult CheakBlood(string BloodName)
        {
            var cheak = db.aBlood.Where(d => d.BloodName.Equals(BloodName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (cheak != null)
            {
                return Json("Sorry Blood Name Already Exits!", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
