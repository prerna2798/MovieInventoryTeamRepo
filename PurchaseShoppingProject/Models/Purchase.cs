using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseShoppingProject.Models
{
    public class Purchase
    {
        [Key]
        public int PusrchaseId { get; set; }
        public int CustomerId { get; set; }
        public List<ProductDTO> Products { get; set; }
        public double Total { get; set; }
    }
}
