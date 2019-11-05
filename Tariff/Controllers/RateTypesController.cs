using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tariff.Models;

namespace Tariff.Controllers
{
    public class RateTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RateTypes
        public ActionResult Index()
        {
            return View(db.RateTypes.ToList());
        }

        // GET: RateTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateType rateType = db.RateTypes.Find(id);
            if (rateType == null)
            {
                return HttpNotFound();
            }
            return View(rateType);
        }

        // GET: RateTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RateTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] RateType rateType)
        {
            if (ModelState.IsValid)
            {
                db.RateTypes.Add(rateType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rateType);
        }

        // GET: RateTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateType rateType = db.RateTypes.Find(id);
            if (rateType == null)
            {
                return HttpNotFound();
            }
            return View(rateType);
        }

        // POST: RateTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] RateType rateType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rateType);
        }

        // GET: RateTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateType rateType = db.RateTypes.Find(id);
            if (rateType == null)
            {
                return HttpNotFound();
            }
            return View(rateType);
        }

        // POST: RateTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateType rateType = db.RateTypes.Find(id);
            db.RateTypes.Remove(rateType);
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
