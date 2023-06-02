using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SupplierRepo
{
    public interface ISupplierRepository
    {
        public IEnumerable<Supplier> GetSupplierList();
        public Supplier GetSupplier(string supplierName);
    }
}
