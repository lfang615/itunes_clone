using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
    public class RoleTypeManager : GenericManager
    {
        public void CreateRType(string name)
        {
            RoleType test = new RoleType()
            {
                Name = name
            };

            DomainContext.RoleTypes.Add(test);
            DomainContext.SaveChanges();
        }

        public List<RoleType> GetRType()
        {
            return DomainContext.RoleTypes.ToList();
        }

        public void UpdateRType(RoleType rType)
        {
            RoleType test = DomainContext.RoleTypes.Where(x => x.Id == rType.Id).FirstOrDefault();

            if(test == null)
            {
                DomainContext.RoleTypes.Add(rType);
                DomainContext.SaveChanges();
            }
            else
            {
                test.Name = rType.Name;

                DomainContext.SaveChanges();
            }
        }

        public void DeleteRType(RoleType rType)
        {
            DomainContext.RoleTypes.Remove(rType);
            DomainContext.SaveChanges();
        }

        public RoleType GetRTypeById(int id)
        {
            return DomainContext.RoleTypes.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
