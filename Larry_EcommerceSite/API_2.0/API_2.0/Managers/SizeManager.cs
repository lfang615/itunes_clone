using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
    public class SizeManager : GenericManager 
    {
        public void CreateSize(string size, int proTypeId, int proId)
        {
            Size test = new Size()
            {
                Size1 = size,
                ProductTypeId = proTypeId,
                ProductId = proId
            };

            DomainContext.Sizes.Add(test);
            DomainContext.SaveChanges();
        }

        public List<Size> GetSizes()
        {
            return DomainContext.Sizes.ToList();
        }

        public void UpdateSize(Size size)
        {
            Size test = DomainContext.Sizes.Where(x => x.Id == size.Id).FirstOrDefault();

            if(test == null)
            {
                DomainContext.Sizes.Add(size);
                DomainContext.SaveChanges();
            }
            else
            {
                test.Size1 = size.Size1;
                test.ProductTypeId = size.ProductTypeId;
                test.ProductId = size.ProductId;

                DomainContext.SaveChanges();
            }
        }

        public void DeleteSize(Size size)
        {
            DomainContext.Sizes.Remove(size);
            DomainContext.SaveChanges();
        }

        public Size GetSizeById(int id)
        {
            return DomainContext.Sizes.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
