using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepo
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetFlowerBouquetById(int flowerBouquetID)
        {
            return OrderDetailDAO.Instance.GetFlowerBouquetById(flowerBouquetID);
        }
        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);
        }
    }
}
