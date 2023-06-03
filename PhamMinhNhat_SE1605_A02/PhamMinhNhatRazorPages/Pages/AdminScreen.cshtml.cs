using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Windows;

namespace PhamMinhNhatRazorPages.Pages
{
    public class AdminScreenModel : PageModel
    {
        
        public IActionResult OnGet()
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && loginMem.Equals("Admin"))
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
