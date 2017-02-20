using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
    public class CartManager : GenericManager
    {
        public Cart CreateCart(int custId, int proId, int quantity, decimal total)
        {
            Cart test = new Cart()
            {
                CustomerId = custId,
                ProductId = proId,
                Quantity = quantity,
                Total = total
            };

            DomainContext.Carts.Add(test);
            DomainContext.SaveChanges();
            return test;
        }

        public List<Cart> GetCart()
        {
            return DomainContext.Carts.ToList();
        }

        public void UpdateCart(Cart cart)
        {
            Cart test = DomainContext.Carts.Where(x => x.Id == cart.Id).FirstOrDefault();

            if(test == null)
            {
                DomainContext.Carts.Add(cart);
                DomainContext.SaveChanges();
            }
            else
            {
                test.CustomerId = cart.CustomerId;
                test.ProductId = cart.ProductId;
                test.Quantity = cart.Quantity;
                test.Total = cart.Total;

                DomainContext.SaveChanges();
            }
        }

        public void DeleteCart(Cart cart)
        {
            DomainContext.Carts.Remove(cart);
            DomainContext.SaveChanges();
        }

       
        public Cart GetCartItemById(int id)
        {
            return DomainContext.Carts.Where(x => x.Id == id).FirstOrDefault();
        }

       
        public int GetCartIdByCustomerId(int custId)
        {
            Model1Container1 context = new Model1Container1();

            int id = (from c in context.Carts
                      join cust in context.Customers
                      on c.Customer.Id equals cust.Id
                      where cust.Id == custId
                      select cust.Id).FirstOrDefault();

            return id;
            
        }

        public List<Cart> GetCartByCustId(int custId)
        {
            return DomainContext.Carts.Where(x => x.CustomerId == custId).ToList();
        }
    }
}
