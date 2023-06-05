using DataAccess.Repository.FlowerBouquetRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CategoryRepo;
using Repository.SupplierRepo;

namespace PhamMinhNhatRazorPages.Pages.FlowerBouquets
{
    public class AddModel : PageModel
    {
        ICategoryRepository categoryRepository { get; set; }
        ISupplierRepository supplierRepository { get; set; }
        IFlowerBouquetRepository flowerBouquetRepository { get; set; }

        public AddModel()
        {
            supplierRepository = new SupplierRepository();
            categoryRepository = new CategoryRepository();
            flowerBouquetRepository = new FlowerBouquetRepository();
        }
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
