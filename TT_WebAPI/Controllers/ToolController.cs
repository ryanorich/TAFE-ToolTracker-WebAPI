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
	/// <summary>
	/// Controller for the Tool table
	/// </summary>
    public class ToolController : ApiController
    {
        private ToolTrackerEntities db = new ToolTrackerEntities();

        // GET: api/Tool
        public IQueryable<Tool> GetTools()
        {
            return db.Tools;
        }

        // GET: api/Tool/5
        [ResponseType(typeof(Tool))]
        public IHttpActionResult GetTool(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        // PUT: api/Tool/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTool(int id, Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tool.ToolID)
            {
                return BadRequest();
            }

            db.Entry(tool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolExists(id))
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

        // POST: api/Tool
        [ResponseType(typeof(Tool))]
        public IHttpActionResult PostTool(Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tools.Add(tool);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tool.ToolID }, tool);
        }

        // DELETE: api/Tool/5
        [ResponseType(typeof(Tool))]
        public IHttpActionResult DeleteTool(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return NotFound();
            }

            db.Tools.Remove(tool);
            db.SaveChanges();

            return Ok(tool);
        }

		// Releases unmanaged reousrces
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		// Checks a the tool exists
        private bool ToolExists(int id)
        {
            return db.Tools.Count(e => e.ToolID == id) > 0;
        }
    }
}