using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public class ProductOperation:IRepositary<Product>
    {
        List<Product> products;
        public ProductOperation()
        {
            products= new List<Product>();
            products.Add(new Product
            {
                ProductId = 1,
                ProductName = "shirt",
                Price = 450,
                Quantity = 20 
            }) ;

        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void DeleteProduct(int id)
        {
            products.Remove(products.FirstOrDefault(a => a.ProductId == id));
        }

        public void EditProduct(int id,Product product)
        {
            var result = products.FirstOrDefault(a => a.ProductId == id);
            result.ProductName = product.ProductName;
            result.Price = product.Price;
            result.Quantity = product.Quantity;
          
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return this.products;
        }
        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(a => a.ProductId == id); ;
        }
        public void IncreaseOrDecreaseQuantity(int id,int n)
        {
            var result = products.FirstOrDefault(a => a.ProductId == id);
            result.Quantity = result.Quantity + n;
        }
    }
}
