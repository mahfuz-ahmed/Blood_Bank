using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class ThanasController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: Thanas
        public ActionResult Index()
        {
            var thanas = db.Thanas.Include(t => t.District);
            return View(thanas.ToList());
        }

        // GET: Thanas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thana thana = db.Thanas.Find(id);
            if (thana == null)
            {
                return HttpNotFound();
            }
            return View(thana);
        }

        // GET: Thanas/Create
        public ActionResult Create()
        {
            ViewBag.District_Id = new SelectList(db.Districts, "DistrictID", "DistrictName");
            return View();
        }

        // POST: Thanas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThanaID,District_Id,ThanaName,Status")] Thana thana)
        {
            if (ModelState.IsValid)
            {
                db.Thanas.Add(thana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District_Id = new SelectList(db.Districts, "DistrictID", "DistrictName", thana.District_Id);
            return View(thana);
        }

        // GET: Thanas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thana thana = db.Thanas.Find(id);
            if (thana == null)
            {
                return HttpNotFound();
            }
            ViewBag.District_Id = new SelectList(db.Districts, "DistrictID", "DistrictName", thana.District_Id);
            return View(thana);
        }

        // POST: Thanas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThanaID,District_Id,ThanaName,Status")] Thana thana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District_Id = new SelectList(db.Districts, "DistrictID", "DistrictName", thana.District_Id);
            return View(thana);
        }

        // GET: Thanas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thana thana = db.Thanas.Find(id);
            if (thana == null)
            {
                return HttpNotFound();
            }
            return View(thana);
        }

        // POST: Thanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) { 
            Thana thana = db.Thanas.Find(id);
            db.Thanas.Remove(thana);
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
