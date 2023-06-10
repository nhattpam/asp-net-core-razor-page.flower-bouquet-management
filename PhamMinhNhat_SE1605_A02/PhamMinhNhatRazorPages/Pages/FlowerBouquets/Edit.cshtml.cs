using BusinessObjects.Models;
using DataAccess.Repository.FlowerBouquetRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Repository.CategoryRepo;
using Repository.SupplierRepo;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages.FlowerBouquets
{
    public class EditModel : PageModel
    {
        public IEnumerable<CategoryViewModel> OptionCategories { get; set; }

        public IEnumerable<SupplierViewModel> OptionSuppliers { get; set; }

        ICategoryRepository categoryRepository { get; set; }

        ISupplierRepository supplierRepository { get; set; }

        IFlowerBouquetRepository flowerBouquetRepository { get; set; }

        [BindProperty]
        public FlowerBouquetViewModel EditFlowerBouquet { get; set; }


        public EditModel()
        {
            supplierRepository = new SupplierRepository();
            categoryRepository = new CategoryRepository();
            flowerBouquetRepository = new FlowerBouquetRepository();
        }


        public IActionResult OnGet(int id)
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && loginMem.Equals("Admin"))
            {
                //MessageBox.Show(id.ToString());
                var flo = flowerBouquetRepository.GetFlowerBouquetsById(id);
                if (flo != null)
                {
                    EditFlowerBouquet = new FlowerBouquetViewModel()
                    {
                        FlowerBouquetId = flo.FlowerBouquetId,
                        FlowerBouquetName = flo.FlowerBouquetName,
                        Description = flo.Description,
                        UnitPrice = flo.UnitPrice,
                        UnitsInStock = flo.UnitsInStock,
                        CategoryId = flo.CategoryId,
                        SupplierId = flo.SupplierId,
                    };
                }
                OptionCategories = ListCates();
                OptionSuppliers = ListSups();
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPost()
        {
            var flowerBouquet = new FlowerBouquet()
            {
                FlowerBouquetId = EditFlowerBouquet.FlowerBouquetId,
                FlowerBouquetName = EditFlowerBouquet.FlowerBouquetName,
                FlowerBouquetStatus = 1,
                Description = EditFlowerBouquet.Description,
                UnitPrice = EditFlowerBouquet.UnitPrice,
                UnitsInStock = EditFlowerBouquet.UnitsInStock,
                CategoryId = EditFlowerBouquet.CategoryId,
                SupplierId = EditFlowerBouquet.SupplierId
            };

            if (string.IsNullOrWhiteSpace(flowerBouquet.FlowerBouquetName)
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
                if (flowerAdd != null)
                {
                    flowerBouquetRepository.Update(flowerBouquet);
                    ViewData["messageAdd"] = "Da Sua thanh cong!";
                    return RedirectToPage("/FlowerBouquets/Index");
                }
                else
                {
                    ViewData["messageInput"] = "KHONG THANH CONG!";
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
