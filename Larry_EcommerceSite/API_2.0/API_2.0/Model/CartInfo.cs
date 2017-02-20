using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Model
{
    [Serializable]
    public class CartInfo
    {
        public CartInfo(Cart cart)
        {
            ProductId = cart.Product.Id;
            ProductPhoto = cart.Product.Photo;
            ProductPrice = (decimal)cart.Product.Price;
            ProductName = cart.Product.Name;
            Quantity = (int)cart.Quantity;
            
        }

        public CartInfo() { }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
