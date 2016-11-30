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
using TemperaturRESTService;
using TemperaturRESTService.Models;

namespace TemperaturRESTService.Controllers
{
    public class TemperatursController : ApiController
    {
        private TemperaturRESTServiceContext db = new TemperaturRESTServiceContext();

        // GET: api/Temperaturs
        public IQueryable<Temperatur> GetTemperaturs()
        {
            return db.Temperaturs;
        }

        // GET: api/Temperaturs/5
        [ResponseType(typeof(Temperatur))]
        public async Task<IHttpActionResult> GetTemperatur(int id)
        {
            Temperatur temperatur = await db.Temperaturs.FindAsync(id);
            if (temperatur == null)
            {
                return NotFound();
            }

            return Ok(temperatur);
        }

        // PUT: api/Temperaturs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTemperatur(int id, Temperatur temperatur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != temperatur.Id)
            {
                return BadRequest();
            }

            db.Entry(temperatur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturExists(id))
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

        // POST: api/Temperaturs
        [ResponseType(typeof(Temperatur))]
        public async Task<IHttpActionResult> PostTemperatur(Temperatur temperatur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Temperaturs.Add(temperatur);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = temperatur.Id }, temperatur);
        }

        // DELETE: api/Temperaturs/5
        [ResponseType(typeof(Temperatur))]
        public async Task<IHttpActionResult> DeleteTemperatur(int id)
        {
            Temperatur temperatur = await db.Temperaturs.FindAsync(id);
            if (temperatur == null)
            {
                return NotFound();
            }

            db.Temperaturs.Remove(temperatur);
            await db.SaveChangesAsync();

            return Ok(temperatur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TemperaturExists(int id)
        {
            return db.Temperaturs.Count(e => e.Id == id) > 0;
        }
    }
}