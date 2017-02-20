using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
    public class PurchaseManager : GenericManager
    {
        public void CreatePurchase(decimal amount, int quantity, int productId, int custId)
        {
            Purchase purchase = new Purchase()
            {
                Amount = amount,
                Quantity = quantity,
                ProductId = productId,
                CustomerId = custId
            };
            DomainContext.Purchases.Add(purchase);
            DomainContext.SaveChanges();
        }

        public List<Purchase> GetPurchases()
        {
            return DomainContext.Purchases.ToList();
        }

        public void UpdatePurchase(Purchase purchase)
        {
            Purchase test = DomainContext.Purchases.Where(x => x.Id == purchase.Id).FirstOrDefault();

            if(test == null)
            {
                DomainContext.Purchases.Add(purchase);
                DomainContext.SaveChanges();
            }
            else
            {
                test.Amount = purchase.Amount;
                test.Quantity = purchase.Quantity;
                test.ProductId = purchase.ProductId;
                test.CustomerId = purchase.CustomerId;

                DomainContext.SaveChanges();
            }
        }

        public void DeletePurchase(Purchase purchase)
        {
            DomainContext.Purchases.Remove(purchase);
            DomainContext.SaveChanges();
        }

        public Purchase GetPurchaseById(int id)
        {
            return DomainContext.Purchases.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
