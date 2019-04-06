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
    public class ordersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/orders
        public IQueryable<order> Getorders()
        {
            return db.orders;
        }

        // GET: api/orders/5
        [ResponseType(typeof(order))]
        public async Task<IHttpActionResult> Getorder(int id)
        {
            order order = await db.orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putorder(int id, order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.orderId)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderExists(id))
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

        // POST: api/orders
        [ResponseType(typeof(order))]
        public async Task<IHttpActionResult> Postorder(order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.orders.Add(order);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (orderExists(order.orderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order.orderId }, order);
        }

        // DELETE: api/orders/5
        [ResponseType(typeof(order))]
        public async Task<IHttpActionResult> Deleteorder(int id)
        {
            order order = await db.orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool orderExists(int id)
        {
            return db.orders.Count(e => e.orderId == id) > 0;
        }
    }
}