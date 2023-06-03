using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhamMinhNhatRazorPages.Pages
{
    public class CustomerScreenModel : PageModel
    {
        public IActionResult OnGet()
        {
            //check customer or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && !loginMem.Equals("Admin"))
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
