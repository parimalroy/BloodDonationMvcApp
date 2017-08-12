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
    public class DistirctsController : Controller
    {
        private BloodDonationDbContext db = new BloodDonationDbContext();

        // GET: /Distircts/
        public ActionResult Index()
        {
            var adistricts = db.aDistricts.Include(d => d.Division);
            return View(adistricts.ToList());
        }

        // GET: /Distircts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Districts districts = db.aDistricts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        // GET: /Distircts/Create
        //[Authorize]
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName");
            return View();
        }

        // POST: /Distircts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DivisionId,DistrictsName")] Districts districts)
        {
            if (ModelState.IsValid)
            {
                db.aDistricts.Add(districts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName", districts.DivisionId);
            return View(districts);
        }

        // GET: /Distircts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Districts districts = db.aDistricts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName", districts.DivisionId);
            return View(districts);
        }

        // POST: /Distircts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DivisionId,DistrictsName")] Districts districts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(districts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName", districts.DivisionId);
            return View(districts);
        }

        // GET: /Distircts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Districts districts = db.aDistricts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        // POST: /Distircts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Districts districts = db.aDistricts.Find(id);
            db.aDistricts.Remove(districts);
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

        public JsonResult CheakDistricts(string DistrictsName)
        {
            var cheak = db.aDistricts.Where(d => d.DistrictsName.Equals(DistrictsName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (cheak != null)
            {
                return Json("Sorry District Name Already Exits!", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
