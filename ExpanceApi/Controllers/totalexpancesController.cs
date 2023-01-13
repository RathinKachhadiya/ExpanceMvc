using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExpanceApi.Models;

namespace ExpanceApi.Controllers
{
    public class totalexpancesController : ApiController
    {
        private ExpanceDBEntities db = new ExpanceDBEntities();

        // GET: api/totalexpances
        public IQueryable<totalexpance> Gettotalexpances()
        {
            return db.totalexpances;
        }

        // GET: api/totalexpances/5
        [ResponseType(typeof(totalexpance))]
        public IHttpActionResult Gettotalexpance(int id)
        {
            totalexpance totalexpance = db.totalexpances.Find(id);
            if (totalexpance == null)
            {
                return NotFound();
            }

            return Ok(totalexpance);
        }

        // PUT: api/totalexpances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttotalexpance(int id, totalexpance totalexpance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != totalexpance.totexpid)
            {
                return BadRequest();
            }

            db.Entry(totalexpance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!totalexpanceExists(id))
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

        // POST: api/totalexpances
        [ResponseType(typeof(totalexpance))]
        public IHttpActionResult Posttotalexpance(totalexpance totalexpance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.totalexpances.Add(totalexpance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = totalexpance.totexpid }, totalexpance);
        }

        // DELETE: api/totalexpances/5
        [ResponseType(typeof(totalexpance))]
        public IHttpActionResult Deletetotalexpance(int id)
        {
            totalexpance totalexpance = db.totalexpances.Find(id);
            if (totalexpance == null)
            {
                return NotFound();
            }

            db.totalexpances.Remove(totalexpance);
            db.SaveChanges();

            return Ok(totalexpance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool totalexpanceExists(int id)
        {
            return db.totalexpances.Count(e => e.totexpid == id) > 0;
        }
    }
}