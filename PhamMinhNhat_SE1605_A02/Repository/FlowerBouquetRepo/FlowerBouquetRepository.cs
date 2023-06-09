using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.FlowerBouquetRepo
{
    public class FlowerBouquetRepository : IFlowerBouquetRepository
    {
        public void DeleteFlowerBouquet(int id)
        {
            FlowerBouquetDAO.Instance.Delete(id);    
        }
        public void DeleteInOrder(int flowerBouquetId)
        {
            FlowerBouquetDAO.Instance.DeleteInOrder(flowerBouquetId);
        }
        public FlowerBouquet GetFlowerBouquetsById(int id)
        {
            return FlowerBouquetDAO.Instance.GetFlowerBouquet(id);
        }

        public IEnumerable<FlowerBouquet> GetFlowerBouquetsList()
        {
            return FlowerBouquetDAO.Instance.GetFlowerBouquetsList();
        }

        public void AddFlowerBouquet(FlowerBouquet flowerBouquet)
        {
            FlowerBouquetDAO.Instance.AddFlowerBouquet(flowerBouquet);
        }

        public void Update(FlowerBouquet flower)
        {
            FlowerBouquetDAO.Instance.Update(flower);
        }
    }
}
