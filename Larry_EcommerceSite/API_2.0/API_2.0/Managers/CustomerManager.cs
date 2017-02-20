using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API_2._0.Managers
{
   public class CustomerManager : GenericManager
    {

        public void SaveCustomer(Customer customer)
        {
            DomainContext.Customers.Add(customer);
            DomainContext.SaveChanges();
        }
        public Customer CreateCustomer(string fName, string lName, DateTime birthday, string phone, string address1, 
            string address2, string city, string state, string zip)
        {
            Customer customer = new Customer()
            {
                FName = fName,
                LName = lName,
                Birthday = birthday,
                PhoneNumber = phone,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                Zip = zip
            };

            SaveCustomer(customer);
            return (customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            DomainContext.Customers.Remove(customer);
            DomainContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer a = DomainContext.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();

            if(a == null)
            {
                DomainContext.Customers.Add(customer);
                DomainContext.SaveChanges();
            }
            else
            {
                a.FName = customer.FName;
                a.LName = customer.LName;
                a.Birthday = customer.Birthday;
                a.PhoneNumber = customer.PhoneNumber;
                a.Address1 = customer.Address1;
                a.Address2 = customer.Address2;
                a.City = customer.City;
                a.State = customer.State;
                a.Zip = customer.Zip;

                DomainContext.SaveChanges();
            }
        }

        public int GetCustomerIdByUserName(string username)
        {
            Model1Container1 context = new Model1Container1();

            int custId = (from c in context.Customers
                          join u in context.Users
                          on c.Id equals u.CustomerId
                          where u.Username == username
                          
                          select u.Customer.Id).FirstOrDefault();

            return custId;


        }
        
        public Customer GetCustomerById(int custId)
        {
            return DomainContext.Customers.Where(x => x.Id == custId).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return DomainContext.Customers.ToList();
        }
    }
}
