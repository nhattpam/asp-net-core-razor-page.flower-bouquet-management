using DataAccess.Repository.FlowerBouquetRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.OrderRepo;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages.Orders
{
    public class IndexModel : PageModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public IOrderRepository orderRepository { get; set; }

        public IndexModel()
        {
            orderRepository = new OrderRepository();
        }
        public IActionResult OnGet()
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && loginMem.Equals("Admin"))
            {
                Orders = List();
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public IEnumerable<OrderViewModel> List()
        {
            var orders = orderRepository.GetOrdersList();
            DateTime dateTime = DateTime.Now;
            var dtos = orders.Select(oo => new OrderViewModel()
            {
                OrderId = oo.OrderId,
                CustomerId = oo.CustomerId,
                OrderDate = oo.OrderDate,
                ShippedDate = oo.ShippedDate,
                Total = oo.Total,
                OrderStatus = oo.OrderStatus,
                Customer = oo.Customer
            });

            return dtos;
        }
    }
}
