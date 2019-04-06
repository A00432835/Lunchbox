using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LunchBox
{
    public class paymentsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/payments
        public IQueryable<payment> Getpayments()
        {
            return db.payments;
        }

        // GET: api/payments/5
        [ResponseType(typeof(payment))]
        public async Task<IHttpActionResult> Getpayment(int id)
        {
            payment payment = await db.payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // PUT: api/payments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpayment(int id, payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.paymentID)
            {
                return BadRequest();
            }

            db.Entry(payment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/payments
        [ResponseType(typeof(payment))]
        public async Task<IHttpActionResult> Postpayment(payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.payments.Add(payment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (paymentExists(payment.paymentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = payment.paymentID }, payment);
        }

        // DELETE: api/payments/5
        [ResponseType(typeof(payment))]
        public async Task<IHttpActionResult> Deletepayment(int id)
        {
            payment payment = await db.payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            db.payments.Remove(payment);
            await db.SaveChangesAsync();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool paymentExists(int id)
        {
            return db.payments.Count(e => e.paymentID == id) > 0;
        }
    }
}