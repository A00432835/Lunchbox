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
    public class itemsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/items
        public IQueryable<item> Getitems()
        {
            return db.items;
        }

        // GET: api/items/5
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Getitem(int id)
        {
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/items/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putitem(int id, item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.itemId)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
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

        // POST: api/items
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Postitem(item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.items.Add(item);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (itemExists(item.itemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.itemId }, item);
        }

        // DELETE: api/items/5
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Deleteitem(int id)
        {
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            db.items.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemExists(int id)
        {
            return db.items.Count(e => e.itemId == id) > 0;
        }
    }
}