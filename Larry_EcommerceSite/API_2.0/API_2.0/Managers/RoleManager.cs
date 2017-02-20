using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
   public class RoleManager : GenericManager
    {
        public Role CreateRole(int roleTypeId, int userId)
        {
            Role role = new Role()
            {
                RoleTypeId = roleTypeId,
                UserId = userId
            };

            DomainContext.Roles.Add(role);
            DomainContext.SaveChanges();
            return (role);
        }

        public List<Role> getRoles()
        {
            return DomainContext.Roles.ToList();
        }

        public void UpdateRoles(Role role)
        {
            Role test = DomainContext.Roles.Where(x => x.Id == role.Id).FirstOrDefault();

            if(test == null)
            {
                DomainContext.Roles.Add(role);
                DomainContext.SaveChanges();
            }
            else
            {
                test.RoleTypeId = role.RoleTypeId;
                test.UserId = role.UserId;

                DomainContext.SaveChanges();
            }
        }

        public void DeleteRole(Role role) {

            DomainContext.Roles.Remove(role);
            DomainContext.SaveChanges();
        }

        public Role GetRoleById(int id)
        {
            return DomainContext.Roles.Where(x => x.Id == id).FirstOrDefault();
        }
            
    }
}
