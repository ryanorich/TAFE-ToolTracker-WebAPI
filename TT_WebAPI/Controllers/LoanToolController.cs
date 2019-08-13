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
    public class LoanToolController : ApiController
    {
        private ToolTrackerEntities db = new ToolTrackerEntities();

        // GET: api/LoanTool
        public IQueryable<LoanTool> GetLoanTools()
        {
            return db.LoanTools;
        }

        // GET: api/LoanTool/5
        [ResponseType(typeof(LoanTool))]
        public IHttpActionResult GetLoanTool(int id)
        {
            LoanTool loanTool = db.LoanTools.Find(id);
            if (loanTool == null)
            {
                return NotFound();
            }

            return Ok(loanTool);
        }

        // PUT: api/LoanTool/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoanTool(int id, LoanTool loanTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loanTool.LoanToolID)
            {
                return BadRequest();
            }

            db.Entry(loanTool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanToolExists(id))
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

        // POST: api/LoanTool
        [ResponseType(typeof(LoanTool))]
        public IHttpActionResult PostLoanTool(LoanTool loanTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoanTools.Add(loanTool);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loanTool.LoanToolID }, loanTool);
        }

        // DELETE: api/LoanTool/5
        [ResponseType(typeof(LoanTool))]
        public IHttpActionResult DeleteLoanTool(int id)
        {
            LoanTool loanTool = db.LoanTools.Find(id);
            if (loanTool == null)
            {
                return NotFound();
            }

            db.LoanTools.Remove(loanTool);
            db.SaveChanges();

            return Ok(loanTool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoanToolExists(int id)
        {
            return db.LoanTools.Count(e => e.LoanToolID == id) > 0;
        }
    }
}