using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
    public class ProductManager : GenericManager
    {
        public void SaveProduct(Product product)
        {
            DomainContext.Products.Add(product);
            DomainContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            DomainContext.Products.Remove(product);
            DomainContext.SaveChanges();
        }

        public void CreateProduct(string proName, decimal price, string photo, int quantity, decimal revenue, int UPC, int productTypeId)
        {

            Product product = new Product()
            {
                Name = proName,
                Price = price,
                Photo = photo,
                Quantity = quantity,
                Revenue = revenue,
                UPC_Code = UPC,
                ProductTypeId = productTypeId
            };

            SaveProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            Product a = DomainContext.Products.Where(x => x.Id == product.Id).FirstOrDefault();

            if (a == null)
            {
                SaveProduct(product);
            }
            else
            {
                a.Name = product.Name;
                a.Photo = product.Photo;
                a.Price = product.Price;
                a.ProductTypeId = product.ProductTypeId;
                a.Quantity = product.Quantity;
                a.Revenue = product.Revenue;
                a.UPC_Code = product.UPC_Code;

                DomainContext.SaveChanges();
            }
        }

        public List<Product> GetProducts()
        {
            return DomainContext.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return DomainContext.Products.Where(x => x.Id == productId).FirstOrDefault();
        }

        public List<Product> GetProductsByTypeId(int productTypeId)
        {
            return DomainContext.Products.Where(x => x.ProductTypeId == productTypeId).ToList();
        }

        public List<Product> GetProductsByTypeName(string name)
        {
            return DomainContext.Products.Where(x => x.ProductType.Name == name).ToList();
        }

        public List<Product> GetProductsByGender(int genderId)
        {
            return DomainContext.Products.Where(x => x.ProductType.GenderId == genderId).ToList();
        }

        public List<Model.CartInfo> GetProductDataByCartId(int cartId)
        {
            Model1Container1 context = new Model1Container1();

            var data = (from p in context.Products
                        join c in context.Carts
                        on p.Id equals c.ProductId
                        where p.Id == c.Product.Id
                        select new Model.CartInfo
                        {

                            CartId = c.Id,
                            ProductName = p.Name,
                            ProductPhoto = p.Photo,
                            ProductPrice = (decimal)p.Price,
                            Quantity = (int)c.Quantity

                        }).ToList();

            return data;
        }

        public Product GetProductByName(string name)
        {
            return DomainContext.Products.Where(x => x.Name == name).FirstOrDefault();

        }
    }

}
