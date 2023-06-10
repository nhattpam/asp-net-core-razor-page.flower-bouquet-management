using BusinessObjects.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccess
{
    public class CustomerDAO
    {
        // Using Singleton Pattern
        private static CustomerDAO instance = null;
        private static object instanceLook = new object();

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        // Get default user from appsettings (admin)
        private Customer GetDefaultMember()
        {
            Customer Default = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                string email = config["account:defaultAccount:email"];
                string password = config["account:defaultAccount:password"];
                Default = new Customer
                {
                    CustomerId = 0,
                    Email = email,
                    Password = password,
                    City = "hello",
                    Country = "sdfsdfsdf",
                    CustomerName = "Admin",
                    Birthday = null
                };
            }
            return Default;
        }

        public IEnumerable<Customer> GetCustomersList()
        {
            IEnumerable<Customer> customers = null;

            try
            {
                var context = new FUFlowerBouquetManagementContext();
                // Get From Database
                customers = context.Customers;
                // Add Default User
                customers = customers.Append(GetDefaultMember());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return customers;
        }

      

        public Customer Login(string email, string password)
        {
            IEnumerable<Customer> customers = GetCustomersList();
            Customer customer = customers.SingleOrDefault(mb => mb.Email.Equals(email) && mb.Password.Equals(password));
            return customer;
        }

    
        public Customer GetCustomer(int customerId)
        {
            Customer cus = null;

            try
            {

                var context = new FUFlowerBouquetManagementContext();
                cus = context.Customers.SingleOrDefault(f => f.CustomerId == customerId); ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cus;
        }


        public void Delete(int customerId)
        {
            try
            {
                Customer f = GetCustomer(customerId);
                if (f != null)
                {
                    var context = new FUFlowerBouquetManagementContext();
                    context.Customers.Remove(f);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddCustomer(Customer c)
        {
            if (c == null)
            {
                throw new Exception("Customer is ####!!");
            }
            try
            {
                if (GetCustomer(c.CustomerId) == null)
                {
                    var context = new FUFlowerBouquetManagementContext();
                    context.Customers.Add(c);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Customer ton tai roi!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Customer c)
        {
            try
            {
                Customer cus = GetCustomer(c.CustomerId);
                if (cus != null)
                {
                    var context = new FUFlowerBouquetManagementContext();
                    cus.CustomerName = c.CustomerName;
                    cus.City = c.City;
                    cus.Email = c.Email;
                    cus.Country = c.Country;
                    cus.Birthday = c.Birthday;
                    context.Customers.Update(cus);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Cus does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //check customer id by name
        public Customer GetCustomerByName(string customerName)
        {
            Customer cus = null;

            try
            {

                var context = new FUFlowerBouquetManagementContext();
                cus = context.Customers.SingleOrDefault(f => f.CustomerName.Equals(customerName.Trim())); 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cus;
        }

        //check customer id by name
        public Customer GetCustomerByEmail(string email)
        {
            Customer cus = null;

            try
            {

                var context = new FUFlowerBouquetManagementContext();
                cus = context.Customers.SingleOrDefault(f => f.Email.Equals(email.Trim()));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cus;
        }

    }
}
