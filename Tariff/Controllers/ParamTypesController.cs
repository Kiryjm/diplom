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
    public class ParamTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ParamTypes
        public ActionResult Index()
        {
            return View(db.ParamTypes.ToList());
        }

        // GET: ParamTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamType paramType = db.ParamTypes.Find(id);
            if (paramType == null)
            {
                return HttpNotFound();
            }
            return View(paramType);
        }

        // GET: ParamTypes/Create
        public ActionResult Create()
        {
            //SelectList paramTypes = new SelectList(db.ParamTypes.ToList(), "Id", "ParamDataType");
            //SelectList paramDataTypes = new SelectList(db.ParamDataType, "Id", "ParamDataType");

            //ViewData["paramDataTypes"] = paramDataTypes;

            return View();
        }

        // POST: ParamTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ParamDataType")] ParamType paramType)
        {
            if (ModelState.IsValid)
            {
                db.ParamTypes.Add(paramType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paramType);
        }

        // GET: ParamTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamType paramType = db.ParamTypes.Find(id);
            if (paramType == null)
            {
                return HttpNotFound();
            }
            return View(paramType);
        }

        // POST: ParamTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DataType")] ParamType paramType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paramType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paramType);
        }

        // GET: ParamTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamType paramType = db.ParamTypes.Find(id);
            if (paramType == null)
            {
                return HttpNotFound();
            }
            return View(paramType);
        }

        // POST: ParamTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParamType paramType = db.ParamTypes.Find(id);
            db.ParamTypes.Remove(paramType);
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
