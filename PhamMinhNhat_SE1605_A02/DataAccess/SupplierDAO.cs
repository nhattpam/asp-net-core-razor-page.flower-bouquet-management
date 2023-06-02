using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SupplierDAO
    {
        // Using singleton Pattern
        private static SupplierDAO instance = null;
        private static object instanceLock = new object();

        public static SupplierDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SupplierDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Supplier> GetSuppliersList()
        {
            IEnumerable<Supplier> suppliers = null;

            try
            {
                var context = new FUFlowerBouquetManagementContext();
                suppliers = context.Suppliers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return suppliers;
        }

        public Supplier GetSupplier(string supplierName)
        {
            Supplier supplier = null;

            try
            {
                var context = new FUFlowerBouquetManagementContext();
                supplier = context.Suppliers.SingleOrDefault(sup => sup.SupplierName.Equals(supplierName.Trim()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return supplier;
        }
    }
}
