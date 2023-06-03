using BusinessObjects.Models;
using DataAccess.Repository.FlowerBouquetRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.OrderDetailRepo;
using System.Windows;

namespace PhamMinhNhatRazorPages.Pages.FlowerBouquets
{

    public class DeleteModel : PageModel
    {
        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; }
        public IFlowerBouquetRepository flowerBouquetRepository { get; set; }
        IOrderDetailRepository orderDetailRepository { get; set; }
        
        public DeleteModel()
        {
            flowerBouquetRepository = new FlowerBouquetRepository();
            orderDetailRepository = new OrderDetailRepository();
            FlowerBouquet = new FlowerBouquet();
        }

        
        public IActionResult OnGet(int id)
        {
            FlowerBouquet = flowerBouquetRepository.GetFlowerBouquetsById(id);
            
            if (FlowerBouquet == null)
            {
                return RedirectToPage("/Index");
            }
            //MessageBox.Show("TIM THAY " + FlowerBouquet.FlowerBouquetName);
            return Page();
        }


        public IActionResult OnPost()
        {
            if(FlowerBouquet == null)
            {
                return RedirectToPage("/FlowerBouquets/Index");
            }
            else
            {
                // if yes->Delete
                IEnumerable<OrderDetail> list = orderDetailRepository.GetFlowerBouquetById(FlowerBouquet.FlowerBouquetId);
                if (list.Where(l => l.FlowerBouquetId == FlowerBouquet.FlowerBouquetId).Any())
                {
                    //MessageBox.Show("Ton tai trong order" + dto.FlowerBouquetName);
                    flowerBouquetRepository.DeleteInOrder(FlowerBouquet.FlowerBouquetId);
                    return RedirectToPage("/FlowerBouquets/Index");
                }
                else
                {
                    //MessageBox.Show("khong Ton tai trong order" + dto.FlowerBouquetName);
                    flowerBouquetRepository.DeleteFlowerBouquet(FlowerBouquet.FlowerBouquetId);
                    return RedirectToPage("/FlowerBouquets/Index");
                }
            }
        }

       
    }
}
