using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
    public class ProductTypeManager : GenericManager
    {
        public void CreateProductType(string name, int genderId)
        {
            ProductType test = new ProductType()
            {
                Name = name,
                GenderId = genderId
            };

            DomainContext.ProductTypes.Add(test);
            DomainContext.SaveChanges();
        }

        public List<ProductType> GetProductTypes()
        {
            return DomainContext.ProductTypes.ToList();
        }

        public void UpdateProductTypes(ProductType productType)
        {
            ProductType test = DomainContext.ProductTypes.Where(x => x.Id == productType.Id).FirstOrDefault();

            if(test == null)
            {
                DomainContext.ProductTypes.Add(productType);
                DomainContext.SaveChanges();
            }
            else
            {
                test.Name = productType.Name;
                test.GenderId = productType.GenderId;

                DomainContext.SaveChanges();
            }
        }

        public void DeleteProductType(ProductType pt)
        {
            DomainContext.ProductTypes.Remove(pt);
            DomainContext.SaveChanges();
        }

        public ProductType GetProductTypeById(int id)
        {
            return DomainContext.ProductTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        public Gender GetGenderById(int id)
        {
            return DomainContext.Genders.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
