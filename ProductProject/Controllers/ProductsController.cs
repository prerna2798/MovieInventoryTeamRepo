using Microsoft.AspNetCore.Mvc;
using ProductProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IRepositary<Product> _repositary;
        public ProductsController(IRepositary<Product> repositary)
        {
            _repositary = repositary;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _repositary.GetAllProducts();
            if (products.Count() == 0)
                return BadRequest("No products");
            else return Ok(products);

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _repositary.GetProductById(id);
            if (product == null)
                return BadRequest("no product is available");
            else
                return Ok(product);

        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            try
            {
                _repositary.AddProduct(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest("could not add");
            }
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                _repositary.EditProduct(id,product);
                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest("could not edit");
            }
        }
        [HttpPut]
        public ActionResult Put(ProductDTO productDTO)
        {
            try
            {
                _repositary.IncreaseOrDecreaseQuantity(productDTO.Id,productDTO.Quantity);
                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest("could not edit");
            }
        }
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repositary.DeleteProduct(id);
                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest("could not be deleted");
            }
        }
    }
}
