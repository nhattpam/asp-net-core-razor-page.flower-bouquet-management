using DataAccess.Repository.FlowerBouquetRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Windows;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages.FlowerBouquets
{
    public class IndexModel : PageModel
    {
        public IEnumerable<FlowerBouquetViewModel> FlowerBouquets { get; set; }
        public IFlowerBouquetRepository flowerBouquetRepository { get; set; }

        public IndexModel()
        {
            flowerBouquetRepository = new FlowerBouquetRepository();
        }
        public IActionResult OnGet()
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && loginMem.Equals("Admin"))
            {
                FlowerBouquets = List();
                return Page();
            }
            return RedirectToPage("/Index");
        }



        public IEnumerable<FlowerBouquetViewModel> List()
        {
            var flowers = flowerBouquetRepository.GetFlowerBouquetsList();

            var dtos = flowers.Select(flower => new FlowerBouquetViewModel()
            {
                FlowerBouquetId = flower.FlowerBouquetId,
                FlowerBouquetName = flower.FlowerBouquetName,
                CategoryId = flower.CategoryId,
                Description = flower.Description,
                UnitPrice = flower.UnitPrice,
                UnitsInStock = flower.UnitsInStock,
                FlowerBouquetStatus = flower.FlowerBouquetStatus,
                SupplierId = flower.SupplierId,
                Category = flower.Category,
                Supplier = flower.Supplier,
                OrderDetails = flower.OrderDetails

            });

            return dtos;
        }


     

    }
}
