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
using TT_WebAPI.Models;

namespace TT_WebAPI.Controllers
{
    public class BorrowerController : ApiController
    {
        private ToolTrackerEntities db = new ToolTrackerEntities();

        // GET: api/Borrower
        public IQueryable<Borrower> GetBorrowers()
        {
            return db.Borrowers;
        }

        // GET: api/Borrower/5
        [ResponseType(typeof(Borrower))]
        public IHttpActionResult GetBorrower(int id)
        {
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return NotFound();
            }

            return Ok(borrower);
        }

        // PUT: api/Borrower/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBorrower(int id, Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != borrower.BorrowerID)
            {
                return BadRequest();
            }

            db.Entry(borrower).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
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

        // POST: api/Borrower
        [ResponseType(typeof(Borrower))]
        public IHttpActionResult PostBorrower(Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Borrowers.Add(borrower);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = borrower.BorrowerID }, borrower);
        }

        // DELETE: api/Borrower/5
        [ResponseType(typeof(Borrower))]
        public IHttpActionResult DeleteBorrower(int id)
        {
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return NotFound();
            }

            db.Borrowers.Remove(borrower);
            db.SaveChanges();

            return Ok(borrower);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BorrowerExists(int id)
        {
            return db.Borrowers.Count(e => e.BorrowerID == id) > 0;
        }
    }
}