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
    public class orderDetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: orderDetails
        public ActionResult Index()
        {
            var orderDetails = db.orderDetails.Include(o => o.item).Include(o => o.order);
            return View(orderDetails.ToList());
        }

        // GET: orderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetail orderDetail = db.orderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: orderDetails/Create
        public ActionResult Create()
        {
            ViewBag.itemID = new SelectList(db.items, "itemId", "snackType");
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus");
            return View();
        }

        // POST: orderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderDetail_ID,orderID,itemID,quantity")] orderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.orderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemID = new SelectList(db.items, "itemId", "snackType", orderDetail.itemID);
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus", orderDetail.orderID);
            return View(orderDetail);
        }

        // GET: orderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetail orderDetail = db.orderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemID = new SelectList(db.items, "itemId", "snackType", orderDetail.itemID);
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus", orderDetail.orderID);
            return View(orderDetail);
        }

        // POST: orderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderDetail_ID,orderID,itemID,quantity")] orderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemID = new SelectList(db.items, "itemId", "snackType", orderDetail.itemID);
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus", orderDetail.orderID);
            return View(orderDetail);
        }

        // GET: orderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetail orderDetail = db.orderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: orderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderDetail orderDetail = db.orderDetails.Find(id);
            db.orderDetails.Remove(orderDetail);
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
