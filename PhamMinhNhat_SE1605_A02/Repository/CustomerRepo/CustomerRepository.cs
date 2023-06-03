using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer c)
        {
            CustomerDAO.Instance.AddCustomer(c);
        }

        public void DeleteCustomer(int id)
        {
            CustomerDAO.Instance.Delete(id);
        }

        public Customer GetCustomerById(int id)
        {
            return CustomerDAO.Instance.GetCustomer(id);
        }

        public IEnumerable<Customer> GetCustomersList()
        {
            return CustomerDAO.Instance.GetCustomersList();
        }

        public Customer Login(string email, string password)
        {
            return CustomerDAO.Instance.Login(email, password);
        }

        public void Update(Customer c)
        {
            CustomerDAO.Instance.Update(c);
        }

        public Customer GetCustomerByName(string customerName)
        {
            return CustomerDAO.Instance.GetCustomerByName(customerName);
        }
    }
}
