using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Tariff.Models;

namespace Tariff.Controllers
{
    public class RatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //internal string GetCheckBox(bool checkboxValue)
        //{
        //    return checkboxValue ? "True" : " False";
        //}


        // GET: Rates
        public ActionResult Index()
        {
            //List<Operator> operators = new List<Operator>(db.Operators.ToList());
            //List<RateType> rateTypes = new List<RateType>(db.RateTypes.ToList());

            //ViewData["Operator"] = operators;
            //ViewData["RateType"] = rateTypes;

            return View(db.Rates.Include(x => x.Operator).Include(x => x.RateType).ToList());
        }

        // GET: Rates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }

            return View(rate);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            SelectList operators = new SelectList(db.Operators.ToList(), "Id", "Name");
            SelectList rateTypes = new SelectList(db.RateTypes.ToList(), "Id", "Name");
            List<ParamType> paramTypes = db.ParamTypes.ToList();
            List<Param> paramsList = new List<Param>();

            foreach (var item in paramTypes)
            {
                paramsList.Add(new Param
                {
                    ParamTypeId = item.Id,
                    ParamType = item,
                    Value = ""
                });
            }

            ViewData["Operator"] = operators;
            ViewData["RateType"] = rateTypes;
            ViewData["Params"] = paramsList;
            return View(new Rate {Params = paramsList});
        }

        // POST: Rates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rate rate)
        {
            //SelectList operators = new SelectList(db.Operators, "Id", "Name");
            //SelectList rateTypes = new SelectList(db.RateTypes, "Id", "Name");

            //ViewData["Operator"] = operators;
            //ViewData["RateType"] = rateTypes;
            //Param item = rate.Params.Find(x => x.ParamType.ParamDataType == ParamDataType.Bool);
            //if (!item.Equals(null))
            //{

            //}

            if (ModelState.IsValid)
            {
                db.Rates.Add(rate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rate);
        }

        // GET: Rates/Edit/5
        public ActionResult Edit(int? id)
        {
            SelectList operators = new SelectList(db.Operators.ToList(), "Id", "Name");
            SelectList rateTypes = new SelectList(db.RateTypes.ToList(), "Id", "Name");
            //SelectList rates = new SelectList(db.Rates.ToList(), "Id", "Name");


            //List<Rate> rates = new List<Rate>(db.Rates.ToList());

            //foreach (var item in rates)
            //{
            //    rates.Add(new Rate
            //    {
            //        ParamTypeId = item.Id,
            //        ParamType = item,
            //        Value = ""
            //    });
            //}


            ViewData["Operator"] = operators;
            ViewData["RateType"] = rateTypes;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rate rate = db.Rates.Include(x => x.Params.Select(y => y.ParamType)).Single(x => x.Id == id);
            if (rate == null)
            {
                return HttpNotFound();
            }

            List<ParamType> paramTypes = db.ParamTypes.ToList();
            HashSet<int> CurrentRateParamTypes = new HashSet<int>();

            foreach (var param in rate.Params)
            {
                CurrentRateParamTypes.Add(param.ParamTypeId);
            }

            foreach (var item in paramTypes)
            {
                if (!CurrentRateParamTypes.Contains(item.Id))
                {
                    rate.Params.Add(new Param
                    {
                        ParamType = item,
                        ParamTypeId = item.Id,
                        RateId = rate.Id,
                        Value = ""
                    });
                }
            }

            return View(rate);
        }

        // POST: Rates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,RateTypeId,OperatorId,Params")]
            Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rate).State = EntityState.Modified;
                foreach (var item in rate.Params)
                {
                    if (item.Id == 0)
                    {
                        db.Params.Add(item);
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }

                    if (item.Value == null)
                        item.Value = "❌";
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rate);
        }

        // GET: Rates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }

            return View(rate);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rate rate = db.Rates.Find(id);
            db.Rates.Remove(rate);
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

        public ActionResult RateInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rate rate = db.Rates.Include(x => x.Operator).Include(x => x.Params.Select(y => y.ParamType))
                .Single(x => x.Id == id);
            if (rate == null)
            {
                return HttpNotFound();
            }

            return View(rate);
        }

        public ActionResult CompareRates(List<int> rate)
        {
            Dictionary<int, string> paramTypeDictionary = new Dictionary<int, string>();
            List<string> paramValueList = new List<string>();
            //List<string> list = new List<string>();
            //IQueryable<string> paramValues = null;


            foreach (var item in db.ParamTypes)
            {
                paramTypeDictionary.Add(item.Id, item.Name);
            }

            foreach (var paramIdItem in paramTypeDictionary.Keys)
            {
                foreach (var rateIdItem in rate)
                {
                   var paramValues = (db.Params.Where(p => p.ParamTypeId == paramIdItem && p.RateId == rateIdItem)
                        .Select(p => p.Value)).FirstOrDefault(); 
                    //list = paramValues.ToList();
                    paramValueList.Add(paramValues);
                }
            }

            //var paramValues = (from p in db.Params
            //    join pt in db.ParamTypes on p.ParamTypeId equals pt.Id
            //    join r in db.Rates on p.RateId equals r.Id
            //    select p.Value);

            //paramValueList = paramValues.ToString();
            ViewBag.paramTypeDictionary = paramTypeDictionary;
            ViewBag.paramValueList = paramValueList;

            List<Rate> rates = db.Rates.Where(x => rate.Contains(x.Id)).ToList();
            return View(rates);
        }
    }
}