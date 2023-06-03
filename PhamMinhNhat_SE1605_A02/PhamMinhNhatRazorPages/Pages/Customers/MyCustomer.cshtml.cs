using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CustomerRepo;
using System.Windows;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages.Customers
{
    public class MyCustomerModel : PageModel
    {
        public ICustomerRepository customerRepository { get; set; }
        public CustomerViewModel CustomerModel { get; set; }
        public MyCustomerModel() 
        {
            customerRepository = new CustomerRepository();
            CustomerModel = new CustomerViewModel();
        }
        public IActionResult OnGet()
        {
            //check customer or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && !loginMem.Equals("Admin"))
            {
                Customer c = customerRepository.GetCustomerByName(loginMem);
                if(c != null)
                {
                    CustomerModel.CustomerId = c.CustomerId;
                }
                CustomerModel = CusModel();
              

                //MessageBox.Show(lo)
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public CustomerViewModel CusModel()
        {
            var customer = customerRepository.GetCustomerById(CustomerModel.CustomerId);
            if (customer != null)
            {
                CustomerModel = new CustomerViewModel()
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    Email = customer.Email,
                    City = customer.City,
                    Country = customer.Country,
                    Birthday = customer.Birthday
                };
            }
            return CustomerModel;
        }
    }
}
