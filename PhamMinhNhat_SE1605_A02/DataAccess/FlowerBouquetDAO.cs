using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FlowerBouquetDAO
    {
        // Singleton
        private static FlowerBouquetDAO instance;
        private static object instanceLock = new object();

        public static FlowerBouquetDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FlowerBouquetDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<FlowerBouquet> GetFlowerBouquetsList()
        {
            IEnumerable<FlowerBouquet> flowerBouquets = null;

            try
            {
                var context = new FUFlowerBouquetManagementContext();
                // Get From Database

                flowerBouquets = context.FlowerBouquets
                            .Include(pro => pro.Category)
                            .Include(pro => pro.Supplier);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return flowerBouquets;
        }

        public FlowerBouquet GetFlowerBouquet(int flowerBouquetId)
        {
            FlowerBouquet flower = null;

            try
            {
              
               var context = new FUFlowerBouquetManagementContext();
                flower = context.FlowerBouquets.SingleOrDefault(f => f.FlowerBouquetId == flowerBouquetId);;
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return flower;
        }


        //khong ton tai trong order
        public void Delete(int flowerBouquetId)
        {
            try
            {
                FlowerBouquet f = GetFlowerBouquet(flowerBouquetId);
                if (f != null)
                {
                    var context = new FUFlowerBouquetManagementContext();
                    context.FlowerBouquets.Remove(f);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Flower does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //ton tai trong order
        public void DeleteInOrder(int flowerBouquetId) 
        {
            try
            {
                FlowerBouquet f = GetFlowerBouquet(flowerBouquetId);
                if (f != null)
                {
                    var context = new FUFlowerBouquetManagementContext();
                    f.FlowerBouquetStatus = 0;
                    context.FlowerBouquets.Update(f);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Flower does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddFlowerBouquet(FlowerBouquet flowerBouquet)
        {
            
                if (GetFlowerBouquet(flowerBouquet.FlowerBouquetId) == null)
                {
                    var context = new FUFlowerBouquetManagementContext();
                    context.FlowerBouquets.Add(flowerBouquet);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Flower is existed!!");
                }
            
        }
    }
}
