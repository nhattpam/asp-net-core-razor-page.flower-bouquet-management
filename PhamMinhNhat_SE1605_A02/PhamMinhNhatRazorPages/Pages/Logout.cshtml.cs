using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Windows;

namespace PhamMinhNhatRazorPages.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if(loginMem == null)
            {
                return RedirectToPage("/Index");
            }
            HttpContext.Session.Remove(loginMem);
            return RedirectToPage("/Index");
        }
    }
}
