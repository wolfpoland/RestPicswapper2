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
using RestPicswapper2.Models;

namespace RestPicswapper2.Controllers
{
    public class LinkisController : ApiController
    {
        private RestPicswapper2Context db = new RestPicswapper2Context();

        // GET: api/Linkis
        public IQueryable<Linki> GetLinkis()
        {
            return db.Linkis;
        }

        // GET: api/Linkis/5
        [ResponseType(typeof(Linki))]
        public async Task<IHttpActionResult> GetLinki(int id)
        {
            Linki linki = await db.Linkis.FindAsync(id);
            if (linki == null)
            {
                return NotFound();
            }

            return Ok(linki);
        }

        // PUT: api/Linkis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLinki(int id, Linki linki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linki.Id)
            {
                return BadRequest();
            }

            db.Entry(linki).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkiExists(id))
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

        // POST: api/Linkis
        [ResponseType(typeof(Linki))]
        public async Task<IHttpActionResult> PostLinki(Linki linki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Linkis.Add(linki);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = linki.Id }, linki);
        }

        // DELETE: api/Linkis/5
        [ResponseType(typeof(Linki))]
        public async Task<IHttpActionResult> DeleteLinki(int id)
        {
            Linki linki = await db.Linkis.FindAsync(id);
            if (linki == null)
            {
                return NotFound();
            }

            db.Linkis.Remove(linki);
            await db.SaveChangesAsync();

            return Ok(linki);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkiExists(int id)
        {
            return db.Linkis.Count(e => e.Id == id) > 0;
        }
    }
}