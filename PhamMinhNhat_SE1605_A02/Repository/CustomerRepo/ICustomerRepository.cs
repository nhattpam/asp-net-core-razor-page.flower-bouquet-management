using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomersList();
        public Customer Login(string email, string password);

        public Customer GetCustomerById(int id);

        //get by name
        public Customer GetCustomerByName(string customerName);

        public void DeleteCustomer(int id);
        public void AddCustomer(Customer c);
        public void Update(Customer c);
    }
}
