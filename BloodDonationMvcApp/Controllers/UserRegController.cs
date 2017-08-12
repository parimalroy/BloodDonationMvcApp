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
    public class UserRegController : Controller
    {
        private BloodDonationDbContext db = new BloodDonationDbContext();

        // GET: /UserReg/
        public ActionResult Index()
        {
            ViewBag.BloodId = new SelectList(db.aBlood, "Id", "BloodName");
            ViewBag.DistrictsId = new SelectList(db.aDistricts, "Id", "DistrictsName");
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName");
            var auserreg = db.aUserReg.Include(u => u.Blood).Include(u => u.Districts).Include(u => u.Division);
            return View(auserreg.ToList());
        }

        [HttpPost]
        public ActionResult Index(int? DivisionId,int? DistrictsId,int? BloodId)
        {

            ViewBag.BloodId = new SelectList(db.aBlood, "Id", "BloodName");
            ViewBag.DistrictsId = new SelectList(db.aDistricts, "Id", "DistrictsName");
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName");
            var auserreg = db.aUserReg.Include(u => u.Blood).Include(u => u.Districts).Include(u => u.Division).Where(a => a.DivisionId == DivisionId && a.DistrictsId == DistrictsId && a.BloodId == BloodId);
            return View(auserreg.ToList());
        }
        // GET: /UserReg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReg userreg = db.aUserReg.Find(id);
            if (userreg == null)
            {
                return HttpNotFound();
            }
            return View(userreg);
        }

        // GET: /UserReg/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.aBlood, "Id", "BloodName");
            ViewBag.DistrictsId = new SelectList(db.aDistricts, "Id", "DistrictsName");
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName");
            return View();
        }

        // POST: /UserReg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Email,Phone,Address,Gender,DivisionId,DistrictsId,BloodId")] UserReg userreg)
        {
            if (ModelState.IsValid)
            {
                db.aUserReg.Add(userreg);
                db.SaveChanges();
                ViewBag.message = "Registerd Sucessfully";
                //return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.aBlood, "Id", "BloodName", userreg.BloodId);
            ViewBag.DistrictsId = new SelectList(db.aDistricts, "Id", "DistrictsName", userreg.DistrictsId);
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName", userreg.DivisionId);
            return View(userreg);
        }

        public ActionResult ShowDetails()
        {
            return RedirectToAction("Index");
        }
        // GET: /UserReg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReg userreg = db.aUserReg.Find(id);
            if (userreg == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.aBlood, "Id", "BloodName", userreg.BloodId);
            ViewBag.DistrictsId = new SelectList(db.aDistricts, "Id", "DistrictsName", userreg.DistrictsId);
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName", userreg.DivisionId);
            return View(userreg);
        }

        // POST: /UserReg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Email,Phone,Address,Gender,DivisionId,DistrictsId,BloodId")] UserReg userreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.aBlood, "Id", "BloodName", userreg.BloodId);
            ViewBag.DistrictsId = new SelectList(db.aDistricts, "Id", "DistrictsName", userreg.DistrictsId);
            ViewBag.DivisionId = new SelectList(db.aDivision, "Id", "DivisionName", userreg.DivisionId);
            return View(userreg);
        }

        // GET: /UserReg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReg userreg = db.aUserReg.Find(id);
            if (userreg == null)
            {
                return HttpNotFound();
            }
            return View(userreg);
        }

        // POST: /UserReg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserReg userreg = db.aUserReg.Find(id);
            db.aUserReg.Remove(userreg);
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

        public JsonResult CheakEmail(string Email)
        {
            var cheak = db.aUserReg.Where(d => d.Email.Equals(Email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (cheak != null)
            {
                return Json("Sorry District Email Already Exits!", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    
        public JsonResult GetProductsByDivisionId(int id)
        {
            List<Districts> regs = new List<Districts>();
            if (id > 0)
            {
                regs = db.aDistricts.Where(p => p.DivisionId == id).ToList();

            }
            else
            {
                regs.Insert(0, new Districts { Id = 0, DistrictsName = "--Select a category first--" });
            }
            var result = (from r in regs
                          select new
                          {
                              id = r.Id,
                              name = r.DistrictsName
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
