using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CustomerRepo;
using System.Windows;
using ViewModel;
using BusinessObjects.Models;
using System.Diagnostics.Metrics;

namespace PhamMinhNhatRazorPages.Pages
{
    public class RegisterModel : PageModel
    {
        public CustomerRepository customerRepository { get; set; }

        [BindProperty]
        public CustomerViewModel AddCustomer { get; set; }

        public RegisterModel()
        {
            customerRepository = new CustomerRepository();
            AddCustomer = new CustomerViewModel();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostRegister()
        {
            Random random = new Random();
            int randomNumber = random.Next();
            int min = 1;
            int max = int.MaxValue;
            int randomNumberInRange = random.Next(min, max);
            var cus = new Customer()
            {
                CustomerId = randomNumberInRange,
                CustomerName = AddCustomer.CustomerName,
                Email = AddCustomer.Email,
                Password = AddCustomer.Password,
                Country = AddCustomer.Country,
                City = AddCustomer.City,
                Birthday = AddCustomer.Birthday,
            };

            var cusInDB = customerRepository.GetCustomerById(cus.CustomerId);
            //check id ton tai, k ton tai thi add 
            if (cusInDB == null)
            {
                //check null
                if (AddCustomer.CustomerName != null && AddCustomer.Country != null
                    && AddCustomer.Birthday != null && AddCustomer.City != null
                    && AddCustomer.Password != null)
                {

                    var cusEmailInDB = customerRepository.GetCustomerByEmail(AddCustomer.Email);
                    if (cusEmailInDB == null)
                    {
                        customerRepository.AddCustomer(cus);
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        ViewData["MessageFailed"] = "Email da ton tai";
                    }
                }
                else
                {
                    ViewData["MessageFailed"] = "Lam on nhap day du du lieu";
                }
                

            }
            else
            {
                ViewData["MessageFailed"] = "Id da ton tai";
            }
            return Page();
        }
    }
}
