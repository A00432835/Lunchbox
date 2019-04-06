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
    public class discountsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/discounts
        public IQueryable<discount> Getdiscounts()
        {
            return db.discounts;
        }

        // GET: api/discounts/5
        [ResponseType(typeof(discount))]
        public async Task<IHttpActionResult> Getdiscount(int id)
        {
            discount discount = await db.discounts.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            return Ok(discount);
        }

        // PUT: api/discounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdiscount(int id, discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discount.disId)
            {
                return BadRequest();
            }

            db.Entry(discount).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!discountExists(id))
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

        // POST: api/discounts
        [ResponseType(typeof(discount))]
        public async Task<IHttpActionResult> Postdiscount(discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.discounts.Add(discount);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (discountExists(discount.disId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = discount.disId }, discount);
        }

        // DELETE: api/discounts/5
        [ResponseType(typeof(discount))]
        public async Task<IHttpActionResult> Deletediscount(int id)
        {
            discount discount = await db.discounts.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            db.discounts.Remove(discount);
            await db.SaveChangesAsync();

            return Ok(discount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool discountExists(int id)
        {
            return db.discounts.Count(e => e.disId == id) > 0;
        }
    }
}