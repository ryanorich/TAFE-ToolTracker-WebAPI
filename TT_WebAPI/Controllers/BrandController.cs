﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TT_WebAPI.Models;

namespace TT_WebAPI.Controllers
{
	/// <summary>
	/// Controller for the Brand table
	/// </summary>
    public class BrandController : ApiController
    {
        private ToolTrackerEntities db = new ToolTrackerEntities();
        
		// GET: api/Brand
        public IQueryable<Brand> GetBrands()
        {
            return db.Brands;
        }

        // GET: api/Brand/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult GetBrand(int id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        // PUT: api/Brand/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != brand.BrandID)
            {
                return BadRequest();
            }
            db.Entry(brand).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brand
        [ResponseType(typeof(Brand))]
        public IHttpActionResult PostBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Brands.Add(brand);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = brand.BrandID }, brand);
        }

        // DELETE: api/Brand/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult DeleteBrand(int id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            db.Brands.Remove(brand);
            db.SaveChanges();
            return Ok(brand);
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

		// Checks if the brand ID is recorded in the database
        private bool BrandExists(int id)
        {
            return db.Brands.Count(e => e.BrandID == id) > 0;
        }
    }
}