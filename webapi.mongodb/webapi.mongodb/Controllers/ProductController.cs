using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.mongodb.Data;
using webapi.mongodb.Entities;

namespace webapi.mongodb.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Productdb _productdb;
        public ProductController(Productdb productdb) => _productdb = _productdb;
        [HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_productdb.Get());
        //}

        //[HttpGet("{id:length(24)}", Name = "GetProducts")]
        //public IActionResult Get(string id)
        //{
        //    var product = _productdb.GetById(id);
        //    if (product == null)
        //        return NotFound();

        //    return Ok(product);
        //}
        [HttpPost]
        public IActionResult Create(Products product)
        {
            _productdb.Create(product);
            return CreatedAtRoute("GetProducts", new
            {
                id = product.Id.ToString()
            }, product);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Products products)
        {
            var product = _productdb.GetById(id);
            if (product == null)
                return NotFound();
            _productdb.Update(id, products);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteById(string id)
        {
            var product = _productdb.GetById(id);
            if (product == null)
                return NotFound();

            _productdb.DeleteById(product.Id);
            return NoContent();

        }



    }
}