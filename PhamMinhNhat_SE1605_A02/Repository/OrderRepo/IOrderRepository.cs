using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepo
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrdersList();

        public IEnumerable<Order> GetOrders(int customerId);
    }
}
