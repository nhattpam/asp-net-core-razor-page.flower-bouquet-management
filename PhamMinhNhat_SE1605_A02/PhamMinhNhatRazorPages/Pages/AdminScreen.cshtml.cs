using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Windows;

namespace PhamMinhNhatRazorPages.Pages
{
    public class AdminScreenModel : PageModel
    {
        public void OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            //MessageBox.Show(name);
        }
    }
}
