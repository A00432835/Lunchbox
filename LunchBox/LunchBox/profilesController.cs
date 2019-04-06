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
    public class profilesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/profiles
        public IQueryable<profile> Getprofiles()
        {
            return db.profiles;
        }

        // GET: api/profiles/5
        [ResponseType(typeof(profile))]
        public async Task<IHttpActionResult> Getprofile(int id)
        {
            profile profile = await db.profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/profiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putprofile(int id, profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.pId)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profileExists(id))
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

        // POST: api/profiles
        [ResponseType(typeof(profile))]
        public async Task<IHttpActionResult> Postprofile(profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profiles.Add(profile);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (profileExists(profile.pId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = profile.pId }, profile);
        }

        // DELETE: api/profiles/5
        [ResponseType(typeof(profile))]
        public async Task<IHttpActionResult> Deleteprofile(int id)
        {
            profile profile = await db.profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.profiles.Remove(profile);
            await db.SaveChangesAsync();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profileExists(int id)
        {
            return db.profiles.Count(e => e.pId == id) > 0;
        }
    }
}