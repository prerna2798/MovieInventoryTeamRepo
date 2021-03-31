using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public interface IRepositary<t>
    {
        public Product GetProductById(int id);
        public IEnumerable<Product> GetAllProducts();
        public void DeleteProduct(int id);
        public void EditProduct(int id,t t);
        public void AddProduct(t t);
        public void IncreaseOrDecreaseQuantity(int id, int n);
    }
}
