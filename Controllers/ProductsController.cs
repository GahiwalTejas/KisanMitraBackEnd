using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using KisanMitraWebApi.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace KisanMitraBackEnd.Controllers
{
    public class ProductsController : ApiController
    {
        private KisanMitraEntities db = new KisanMitraEntities();

        // GET: api/Products
        public IHttpActionResult GetProducts()
        {
            var products = db.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("api/Products/Search")]
        public IHttpActionResult Search(string keyword)

        {
            var results = db.Products
                .Where(p => p.productName.StartsWith(keyword))
                .ToList();


            return Ok(results);
        }

        // GET: api/Products/5
        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products
                .Where(p => p.userId == id)
                .ToList();

            return Ok(product);
        }

        // PUT: api/Products/5
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.productId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.productId }, product);
        }

        // DELETE: api/Products/5
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.productId == id) > 0;
        }
    }
}
