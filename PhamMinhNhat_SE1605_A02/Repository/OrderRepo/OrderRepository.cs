using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrders(int customerId)
        {
            return OrderDAO.Instance.GetOrders(customerId);
        }

        public IEnumerable<Order> GetOrdersList()
        {
            return OrderDAO.Instance.GetOrdersList();
        }
    }
}
