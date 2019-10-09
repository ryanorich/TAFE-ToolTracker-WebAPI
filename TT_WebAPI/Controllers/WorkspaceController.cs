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
	/// Controller for the Workspace table
	/// </summary>
    public class WorkspaceController : ApiController
    {
        private ToolTrackerEntities db = new ToolTrackerEntities();

        // GET: api/Workspace
        public IQueryable<Workspace> GetWorkspaces()
        {
            return db.Workspaces;
        }

        // GET: api/Workspace/5
        [ResponseType(typeof(Workspace))]
        public IHttpActionResult GetWorkspace(int id)
        {
            Workspace workspace = db.Workspaces.Find(id);
            if (workspace == null)
            {
                return NotFound();
            }

            return Ok(workspace);
        }

        // PUT: api/Workspace/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkspace(int id, Workspace workspace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workspace.WorkspaceID)
            {
                return BadRequest();
            }

            db.Entry(workspace).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkspaceExists(id))
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

        // POST: api/Workspace
        [ResponseType(typeof(Workspace))]
        public IHttpActionResult PostWorkspace(Workspace workspace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workspaces.Add(workspace);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workspace.WorkspaceID }, workspace);
        }

        // DELETE: api/Workspace/5
        [ResponseType(typeof(Workspace))]
        public IHttpActionResult DeleteWorkspace(int id)
        {
            Workspace workspace = db.Workspaces.Find(id);
            if (workspace == null)
            {
                return NotFound();
            }

            db.Workspaces.Remove(workspace);
            db.SaveChanges();

            return Ok(workspace);
        }

		// Releases unmanaged resources
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		// Checks if a workspace exists
        private bool WorkspaceExists(int id)
        {
            return db.Workspaces.Count(e => e.WorkspaceID == id) > 0;
        }
    }
}