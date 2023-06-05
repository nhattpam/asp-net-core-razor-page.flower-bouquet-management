using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhamMinhNhatRazorPages.Pages.Customers;
using Repository.CustomerRepo;
using Repository.OrderDetailRepo;
using Repository.OrderRepo;
using ViewModel;
using System.Windows;
namespace PhamMinhNhatRazorPages.Pages.Orders
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public IEnumerable<OrderDetailViewModel> OrdeDetailModel { get; set; }
        public IOrderDetailRepository orderDetailRepository { get; set; }
        public OrderViewModel orderViewModel { get; set; }

        public DetailModel()
        {
            orderDetailRepository = new OrderDetailRepository();
            orderViewModel = new OrderViewModel();
        }
        public IActionResult OnGet(int id)
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && loginMem.Equals("Admin"))
            {
                orderViewModel.OrderId = id;
                OrdeDetailModel = List();
                MessageBox.Show(orderViewModel.OrderId.ToString());

                return Page();
            }
            return RedirectToPage("/Index");
        }

        public IEnumerable<OrderDetailViewModel> List()
        {
            var orderDetailsByOrderId = orderDetailRepository.GetOrderDetailByOrderId(orderViewModel.OrderId);

            var dtos = orderDetailsByOrderId.Select(oo => new OrderDetailViewModel()
            {
                OrderId = oo.OrderId,
                Discount = oo.Discount,
                Quantity = oo.Quantity,
                FlowerBouquet = oo.FlowerBouquet,
                UnitPrice = oo.UnitPrice,
            });
            return dtos;
        }
    }
}
