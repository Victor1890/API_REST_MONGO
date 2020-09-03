using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Models;
using API_REST.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_REST.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductsCollection db = new ProductsCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await db.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProductsDe(string id)
        {
            if (id == string.Empty)
                return BadRequest();

            var result = await db.GetProductsById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducts([FromBody] Products products)
        {
            if (products == null)
                return BadRequest();

            if (products.Name == string.Empty)
                ModelState.AddModelError("Name", "The products shouldn't be Empty");

            await db.InsertProducts(products);

            return Created("The Products is Created",true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducts([FromBody] Products products, string id)
        {
            if (products == null)
                return BadRequest();

            if (products.Name == string.Empty)
                ModelState.AddModelError("Name", "The products shouldn't be Empty");

            products.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProducts(products);

            return Created("The Products is Created", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(string id)
        {
            if (id == string.Empty)
                return BadRequest();

            await db.DeleteProducts(id);
            return NoContent();
        }
    }
}