﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KisanMitraWebApi.Models;

namespace KisanMitraWebApi.Controllers
{
    public class ProductCategoriesController : ApiController
    {
        private KisanMitraEntities db = new KisanMitraEntities();

        // GET: api/ProductCategories
        public IQueryable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories;
        }

        // GET: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory))]
        public IQueryable<Product> GetProductCategory(int id)
        {
            var categoryId = id; // Specify the prodCatId you want to filter by

            var productsInCategory = db.Products
                .Where(p => db.ProductSubCategories
                    .Where(pc => pc.prodCatId == categoryId)
                    .Select(pc => pc.prodSubCatId)
                    .Contains(p.prodSubCatId))
               ;


            return productsInCategory;
        }

        // PUT: api/ProductCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductCategory(int id, ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productCategory.prodCatId)
            {
                return BadRequest();
            }

            db.Entry(productCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        // POST: api/ProductCategories
        [ResponseType(typeof(ProductCategory))]
        public IHttpActionResult PostProductCategory(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductCategories.Add(productCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productCategory.prodCatId }, productCategory);
        }

        // DELETE: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory))]
        public IHttpActionResult DeleteProductCategory(int id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();

            return Ok(productCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoryExists(int id)
        {
            return db.ProductCategories.Count(e => e.prodCatId == id) > 0;
        }
    }
}