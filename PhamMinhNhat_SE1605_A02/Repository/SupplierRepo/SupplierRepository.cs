using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SupplierRepo
{
    public class SupplierRepository : ISupplierRepository
    {
        public IEnumerable<Supplier> GetSupplierList()
        {
            return SupplierDAO.Instance.GetSuppliersList();
        }
        public Supplier GetSupplier(string supplierName)
        {
            return SupplierDAO.Instance.GetSupplier(supplierName);
        }
    }
}
