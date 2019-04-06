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
    public class paymentsController : Controller
    {
        private Model1 db = new Model1();

        // GET: payments
        public ActionResult Index()
        {
            var payments = db.payments.Include(p => p.discount).Include(p => p.order);
            return View(payments.ToList());
        }

        // GET: payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: payments/Create
        public ActionResult Create()
        {
            ViewBag.discountID = new SelectList(db.discounts, "disId", "couponCode");
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus");
            return View();
        }

        // POST: payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paymentID,nameOnCard,cardType,cardNumber,orderID,expiryDate,cvv,discountID,totalPrice")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.discountID = new SelectList(db.discounts, "disId", "couponCode", payment.discountID);
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus", payment.orderID);
            return View(payment);
        }

        // GET: payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.discountID = new SelectList(db.discounts, "disId", "couponCode", payment.discountID);
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus", payment.orderID);
            return View(payment);
        }

        // POST: payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paymentID,nameOnCard,cardType,cardNumber,orderID,expiryDate,cvv,discountID,totalPrice")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.discountID = new SelectList(db.discounts, "disId", "couponCode", payment.discountID);
            ViewBag.orderID = new SelectList(db.orders, "orderId", "orderStatus", payment.orderID);
            return View(payment);
        }

        // GET: payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            payment payment = db.payments.Find(id);
            db.payments.Remove(payment);
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
