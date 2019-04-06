using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LunchBox
{
    public class scheduleTypesController : Controller
    {
        private Model1 db = new Model1();

        // GET: scheduleTypes
        public ActionResult Index()
        {
            return View(db.scheduleTypes.ToList());
        }

        // GET: scheduleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scheduleType scheduleType = db.scheduleTypes.Find(id);
            if (scheduleType == null)
            {
                return HttpNotFound();
            }
            return View(scheduleType);
        }

        // GET: scheduleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scheduleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scheduleID,scheduleType1")] scheduleType scheduleType)
        {
            if (ModelState.IsValid)
            {
                db.scheduleTypes.Add(scheduleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduleType);
        }

        // GET: scheduleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scheduleType scheduleType = db.scheduleTypes.Find(id);
            if (scheduleType == null)
            {
                return HttpNotFound();
            }
            return View(scheduleType);
        }

        // POST: scheduleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scheduleID,scheduleType1")] scheduleType scheduleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleType);
        }

        // GET: scheduleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scheduleType scheduleType = db.scheduleTypes.Find(id);
            if (scheduleType == null)
            {
                return HttpNotFound();
            }
            return View(scheduleType);
        }

        // POST: scheduleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scheduleType scheduleType = db.scheduleTypes.Find(id);
            db.scheduleTypes.Remove(scheduleType);
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
