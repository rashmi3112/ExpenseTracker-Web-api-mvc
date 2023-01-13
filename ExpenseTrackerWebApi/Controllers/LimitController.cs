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
using ExpenseTrackerWebApi.Models;

namespace ExpenseTrackerWebApi.Controllers
{
    public class LimitController : ApiController
    {
        private expenseDbEntities db = new expenseDbEntities();

        // GET: api/Limit
        public IQueryable<Limit> GetLimits()
        {
            return db.Limits;
        }

        // GET: api/Limit/5
        [ResponseType(typeof(Limit))]
        public IHttpActionResult GetLimit(int id)
        {
            Limit limit = db.Limits.Find(id);
            if (limit == null)
            {
                return NotFound();
            }

            return Ok(limit);
        }

        // PUT: api/Limit/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLimit(int id, Limit limit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != limit.limitId)
            {
                return BadRequest();
            }

            db.Entry(limit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimitExists(id))
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

        // POST: api/Limit
        [ResponseType(typeof(Limit))]
        public IHttpActionResult PostLimit(Limit limit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Limits.Add(limit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = limit.limitId }, limit);
        }

        // DELETE: api/Limit/5
        [ResponseType(typeof(Limit))]
        public IHttpActionResult DeleteLimit(int id)
        {
            Limit limit = db.Limits.Find(id);
            if (limit == null)
            {
                return NotFound();
            }

            db.Limits.Remove(limit);
            db.SaveChanges();

            return Ok(limit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LimitExists(int id)
        {
            return db.Limits.Count(e => e.limitId == id) > 0;
        }
    }
}