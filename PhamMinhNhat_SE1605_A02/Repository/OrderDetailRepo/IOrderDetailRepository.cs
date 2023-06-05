using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepo
{
    public interface IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetFlowerBouquetById(int flowerBouquetID);

        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId);
    }
}
