using BusinessObjects.Models;
using DataAccess.Repository.FlowerBouquetRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CategoryRepo;
using Repository.SupplierRepo;
using System.Windows;
using ViewModel;
using static NuGet.Packaging.PackagingConstants;

namespace PhamMinhNhatRazorPages.Pages.FlowerBouquets
{
    public class AddModel : PageModel
    {
        public IEnumerable<CategoryViewModel> OptionCategories { get; set; }
        public IEnumerable<SupplierViewModel> OptionSuppliers { get; set; }
        ICategoryRepository categoryRepository { get; set; }
        ISupplierRepository supplierRepository { get; set; }
        IFlowerBouquetRepository flowerBouquetRepository { get; set; }

        [BindProperty]
        public FlowerBouquetViewModel AddFlowerBouquet { get; set; }

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
                OptionCategories = ListCates();
                OptionSuppliers = ListSups();
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPost() {
            var flowerBouquet = new FlowerBouquet()
            {
                FlowerBouquetId = AddFlowerBouquet.FlowerBouquetId,
                FlowerBouquetName = AddFlowerBouquet.FlowerBouquetName,
                FlowerBouquetStatus = 1,
                Description = AddFlowerBouquet.Description,
                UnitPrice = AddFlowerBouquet.UnitPrice,
                UnitsInStock = AddFlowerBouquet.UnitsInStock,
                CategoryId = AddFlowerBouquet.CategoryId,
                SupplierId = AddFlowerBouquet.SupplierId
            };

            if (flowerBouquet.FlowerBouquetId == 0 || string.IsNullOrWhiteSpace(flowerBouquet.FlowerBouquetName)
                || string.IsNullOrWhiteSpace(flowerBouquet.Description) || flowerBouquet.UnitPrice == 0
                || flowerBouquet.UnitsInStock < 0)
            {

                OptionCategories = ListCates();
                OptionSuppliers = ListSups();
                ViewData["messageInput"] = "Lam on nhap day du thong tin va khong chua khoang trang";


            }
            else
            {
                var flowerAdd = flowerBouquetRepository.GetFlowerBouquetsById(flowerBouquet.FlowerBouquetId);
                if (flowerAdd == null)
                {
                    flowerBouquetRepository.AddFlowerBouquet(flowerBouquet);
                    ViewData["messageId"] = "Da them thanh cong!";
                    return RedirectToPage("Index");
                }
                else
                {
                    ViewData["messageInput"] = "Da trung ID!";
                }

            }


            OptionCategories = ListCates();
            OptionSuppliers = ListSups();

            return Page();

        }

        //option categories
        public IEnumerable<CategoryViewModel> ListCates()
        {
            var categories = categoryRepository.GetCategoryList();
            var dtos = categories.Select(ca => new CategoryViewModel()
            {
                CategoryId = ca.CategoryId,
                CategoryName = ca.CategoryName,
                CategoryDescription = ca.CategoryDescription

            });

            return dtos;
        }
        //option suppliers
        public IEnumerable<SupplierViewModel> ListSups()
        {
            var suppliers = supplierRepository.GetSupplierList();
            var dtos = suppliers.Select(ca => new SupplierViewModel()
            {
                SupplierId = ca.SupplierId,
                SupplierName = ca.SupplierName,
                SupplierAddress = ca.SupplierAddress,
                Telephone = ca.Telephone

            });

            return dtos;
        }

    }
}
