using Microsoft.AspNetCore.Mvc;
using PurchaseShoppingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PurchaseShoppingProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        static ProductDTO productDTO = new ProductDTO()
        {
            Id = 101,
            Name = "Product1",
            Price = 1000,
            Quantity = 2
        };

        static List<ProductDTO> products = new List<ProductDTO>() { productDTO };
        public static double total()
        {
            double sum = 0;
            foreach(var i in products)
            {
                sum = i.Price * i.Quantity+sum;
            }
            return sum;
        }


        static Purchase purchase = new Purchase()
        {
            PusrchaseId = 1,
            CustomerId = 1,
            Products =products,
            Total = total()
        };

        static List<Purchase> purchaseList = new List<Purchase>() { purchase };

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(purchaseList); 
        }

        [HttpPost]
        public void Add([FromBody] Purchase purchase)
        {
            purchaseList.Add(purchase);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                purchaseList.Remove(purchaseList.FirstOrDefault(a => a.PusrchaseId == id));
                return Ok("success");
            }
            catch (Exception e)
            {
                return BadRequest("not found");
            }

        }

        //[HttpDelete("{id}")]
        //public void cancel(int id)
        //{
        //    products.Remove(products.FirstOrDefault(a => a.Id == id));
        //}
    }
}
