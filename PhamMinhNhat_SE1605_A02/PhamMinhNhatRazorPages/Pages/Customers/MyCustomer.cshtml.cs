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
        [BindProperty]
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
            int loginMemId = Int32.Parse(HttpContext.Session.GetString("loginMemId"));
            if (loginMem != null && !loginMem.Equals("Admin"))
            {
                Customer c = customerRepository.GetCustomerById(loginMemId);
                if (c != null)
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

        //update Profile
        public IActionResult OnPost()
        {
            //MessageBox.Show(CustomerModel.CustomerName);

            if (CustomerModel.CustomerName != null && CustomerModel.City != null && CustomerModel.Country != null)
            {
                var customerUpdate = new Customer()
                {
                    CustomerId= CustomerModel.CustomerId,
                    CustomerName = CustomerModel.CustomerName,
                    City = CustomerModel.City,
                    Country = CustomerModel.Country,
                    Birthday = CustomerModel.Birthday,
                    Email = CustomerModel.Email,
                };
                var customerHasEmail = customerRepository.GetCustomerByEmail(customerUpdate.Email);
                var customerById = customerRepository.GetCustomerById(Int32.Parse(HttpContext.Session.GetString("loginMemId")));
                //neu khong ton tai trong db thi update
                if (customerHasEmail == null)
                {
                    customerRepository.Update(customerUpdate);
                    ViewData["MessageSuccess"] = "Update Successfully";
                } else
                {
                    if (customerById.Email.Equals(CustomerModel.Email))
                    {
                        customerRepository.Update(customerUpdate);
                        ViewData["MessageSuccess"] = "Update Successfully";
                    }
                    else
                    {
                        ViewData["MessageFailed"] = "Email da ton tai";
                    }
                }
               
               
                
            }
            else
            {
                ViewData["MessageFailed"] = "PLease fill data";
                return Page();
            }
            return Page();
        }
    }
}
