using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        // Singleton
        private static OrderDetailDAO instance;
        private static object instanceLock = new object();

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            IEnumerable<OrderDetail> orderDetails = null;

            try
            {
                var context = new FUFlowerBouquetManagementContext();
                // Get From Database

                orderDetails = context.OrderDetails
                            .Include(o => o.Order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orderDetails;
        }

        public IEnumerable<OrderDetail> GetFlowerBouquetById(int flowerBouquetID)
        {
            IEnumerable<OrderDetail> list = null;
            
            list = GetOrderDetails().Where(t => t.FlowerBouquetId== flowerBouquetID).ToList();
            return list;
        }
    }
}
