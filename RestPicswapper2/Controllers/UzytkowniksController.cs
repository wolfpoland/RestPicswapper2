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
    public class UzytkowniksController : ApiController
    {
        private RestPicswapper2Context db = new RestPicswapper2Context();

        // GET: api/Uzytkowniks
        [ActionName("getAll")]
        public List<Uzytkownik> GetUzytkowniks()
        {
            List<Uzytkownik> lista = db.Uzytkowniks.ToList();
            List<Uzytkownik> nowa = new List<Uzytkownik>();
            foreach (Uzytkownik item in lista)
            {
                if (nowa.Count == 0)
                {
                    nowa.Add(item);
                }else
                {
                    bool cosBylo = false;
                    foreach (Uzytkownik item2 in nowa)
                    {
                        if(item.imie==item2.imie && item2.mail==item.mail && item.nazwisko == item2.nazwisko)
                        {
                            db.Uzytkowniks.Remove(item);
                            cosBylo = true;
                        }
                    }
                    if (cosBylo == false)
                    {
                        nowa.Add(item);
                    }
                }
            }
            return nowa;
        }


        // GET: api/Uzytkowniks/5
        [ResponseType(typeof(Uzytkownik))]
        [ActionName("getuz")]
        public async Task<IHttpActionResult> GetUzytkownik(int id)
        {
            Uzytkownik uzytkownik = await db.Uzytkowniks.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return Ok(uzytkownik);
        }

        // PUT: api/Uzytkowniks/5
        [ResponseType(typeof(void))]
        [ActionName("putuz")]
        public async Task<IHttpActionResult> PutUzytkownik(int id, Uzytkownik uzytkownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uzytkownik.Id)
            {
                return BadRequest();
            }

            db.Entry(uzytkownik).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzytkownikExists(id))
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

        // POST: api/Uzytkowniks
        [ResponseType(typeof(Uzytkownik))]
        [ActionName("postuz")]
        public async Task<IHttpActionResult> PostUzytkownik(Uzytkownik uzytkownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uzytkowniks.Add(uzytkownik);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = uzytkownik.Id }, uzytkownik);
        }

        // DELETE: api/Uzytkowniks/5
        [ResponseType(typeof(Uzytkownik))]
        [ActionName("deleteuz")]
        public async Task<IHttpActionResult> DeleteUzytkownik(int id)
        {
            Uzytkownik uzytkownik = await db.Uzytkowniks.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            db.Uzytkowniks.Remove(uzytkownik);
            await db.SaveChangesAsync();

            return Ok(uzytkownik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UzytkownikExists(int id)
        {
            return db.Uzytkowniks.Count(e => e.Id == id) > 0;
        }
        [HttpGet]
        [ActionName("logo")]
        public Uzytkownik logo(string mail, string haslo)
        {
            System.Diagnostics.Debug.WriteLine("Jestem w logo");
            Uzytkownik uz = db.Uzytkowniks.First(k => k.mail == mail && k.haslo == haslo);
            if (uz == null)
            {
                System.Diagnostics.Debug.WriteLine("NULL");
                return null;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("uZYTKOWNIK");
                return uz;
            }
        }
    }
   
}