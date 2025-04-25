using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Model
{
    public class Product_Model
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        public Seller_Model Seller { get; set; }
        public int Quantity { get; set; }
        public DateTime Expiration_date { get; set; }
        public int Reference { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount_price { get; set; }

    }
}
