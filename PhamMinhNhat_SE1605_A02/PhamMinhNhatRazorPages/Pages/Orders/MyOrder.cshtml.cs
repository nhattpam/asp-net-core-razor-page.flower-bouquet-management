using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.CustomerRepo;
using Repository.OrderRepo;
using ViewModel;

namespace PhamMinhNhatRazorPages.Pages.Orders
{
    public class MyOrderModel : PageModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public IOrderRepository orderRepository { get; set; }
        public CustomerViewModel CustomerModel { get; set; }
        public ICustomerRepository customerRepository { get; set; }

        public MyOrderModel()
        {
            orderRepository = new OrderRepository();
            CustomerModel = new CustomerViewModel();
            customerRepository = new CustomerRepository();
        }
        public IActionResult OnGet()
        {
            //check admin or null
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null && !loginMem.Equals("Admin"))
            {
                Customer c = customerRepository.GetCustomerByName(loginMem);
                if (c != null)
                {
                    CustomerModel.CustomerId = c.CustomerId;
                }
                Orders = List();
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public IEnumerable<OrderViewModel> List()
        {
            var ordersByCus = orderRepository.GetOrders(CustomerModel.CustomerId);

            var dtos = ordersByCus.Select(oo => new OrderViewModel()
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
