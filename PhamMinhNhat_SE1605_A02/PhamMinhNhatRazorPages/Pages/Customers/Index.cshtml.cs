using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CustomerRepo;
using System.Windows;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }
        public ICustomerRepository customerRepository { get; set; }


        public IndexModel()
        {
            customerRepository = new CustomerRepository();
        }

        public IActionResult OnGet()
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if(loginMem != null && loginMem.Equals("Admin"))
            {
                Customers = List();
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public IEnumerable<CustomerViewModel> List()
        {
            var cuses = customerRepository.GetCustomersList();

            var dtos = cuses.Select(c => new CustomerViewModel()
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                Email = c.Email,
                City = c.City,
                Birthday = c.Birthday,
                Country = c.Country
            });

            return dtos;
        }
    }
}
