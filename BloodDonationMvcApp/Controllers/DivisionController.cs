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
    public class DivisionController : Controller
    {
        private BloodDonationDbContext db = new BloodDonationDbContext();

        // GET: /Division/
        public ActionResult Index()
        {
            return View(db.aDivision.ToList());
        }

        // GET: /Division/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.aDivision.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // GET: /Division/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DivisionName")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.aDivision.Add(division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(division);
        }

        // GET: /Division/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.aDivision.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DivisionName")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(division);
        }

        // GET: /Division/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.aDivision.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Division division = db.aDivision.Find(id);
            db.aDivision.Remove(division);
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

        public JsonResult CheakDivision(string DivisionName)
        {
            var cheak = db.aDivision.Where(p => p.DivisionName.Equals(DivisionName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (cheak!=null)
            {
                return Json("Sorry This Division Already Exits", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
