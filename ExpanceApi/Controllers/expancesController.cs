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
    public class expancesController : ApiController
    {
        private ExpanceDBEntities db = new ExpanceDBEntities();

        // GET: api/expances
        public IQueryable<expance> Getexpances()
        {
            return db.expances;
        }

        // GET: api/expances/5
        [ResponseType(typeof(expance))]
        public IHttpActionResult Getexpance(int id)
        {
            expance expance = db.expances.Find(id);
            if (expance == null)
            {
                return NotFound();
            }

            return Ok(expance);
        }

        // PUT: api/expances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putexpance(int id, expance expance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expance.expid)
            {
                return BadRequest();
            }

            db.Entry(expance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!expanceExists(id))
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

        // POST: api/expances
        [ResponseType(typeof(expance))]
        public IHttpActionResult Postexpance(expance expance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.expances.Add(expance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expance.expid }, expance);
        }

        // DELETE: api/expances/5
        [ResponseType(typeof(expance))]
        public IHttpActionResult Deleteexpance(int id)
        {
            expance expance = db.expances.Find(id);
            if (expance == null)
            {
                return NotFound();
            }

            db.expances.Remove(expance);
            db.SaveChanges();

            return Ok(expance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool expanceExists(int id)
        {
            return db.expances.Count(e => e.expid == id) > 0;
        }
    }
}