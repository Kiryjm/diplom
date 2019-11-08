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
    public class ParamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Params
        public ActionResult Index()
        {
            return View(db.Params.ToList());
        }

        // GET: Params/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Param param = db.Params.Find(id);
            if (param == null)
            {
                return HttpNotFound();
            }
            return View(param);
        }

        // GET: Params/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Params/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParamName,ParamValue")] Param param)
        {
            if (ModelState.IsValid)
            {
                db.Params.Add(param);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(param);
        }

        // GET: Params/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Param param = db.Params.Find(id);
            if (param == null)
            {
                return HttpNotFound();
            }
            return View(param);
        }

        // POST: Params/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParamName,ParamValue")] Param param)
        {
            if (ModelState.IsValid)
            {
                db.Entry(param).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(param);
        }

        // GET: Params/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Param param = db.Params.Find(id);
            if (param == null)
            {
                return HttpNotFound();
            }
            return View(param);
        }

        // POST: Params/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Param param = db.Params.Find(id);
            db.Params.Remove(param);
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
