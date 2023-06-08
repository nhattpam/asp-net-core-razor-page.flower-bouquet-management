using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CustomerRepo;
using System.Windows;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        //LOGIN
        ICustomerRepository customerRepository { get; set; }

        [BindProperty]
        public LoginViewModel LoginMember { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            customerRepository = new CustomerRepository();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            String email = LoginMember.Email;
            String password = LoginMember.Password;

            if(email != null && password != null)
            {
                var customer = customerRepository.Login(email, password);
                if (customer != null)
                {
                    var dto = new LoginViewModel()
                    {
                        CustomerId = customer.CustomerId,
                        CustomerName = customer.CustomerName,
                        Email = customer.Email,
                        Password = customer.Password
                    };
                    //luu vo session
                    
                    if (dto.CustomerName.Equals("Admin"))
                    {
                        HttpContext.Session.SetString("loginMem", dto.CustomerName);
                        HttpContext.Session.SetString("loginMemId", dto.CustomerId.ToString());
                        return RedirectToPage("./AdminScreen");
                    }
                    else
                    {
                        HttpContext.Session.SetString("loginMem", dto.CustomerName);
                        HttpContext.Session.SetString("loginMemId", dto.CustomerId.ToString());
                        return RedirectToPage("./CustomerScreen");
                    }
                }
                else
                {
                    ViewData["loginFailed"] = "Khong tim thay tai khoan";
                    return RedirectToPage("/Index");
                }

                

            }
            ViewData["loginFailed"] = "Khong tim thay tai khoan";
            return RedirectToPage("/Index");

        }
    }
}