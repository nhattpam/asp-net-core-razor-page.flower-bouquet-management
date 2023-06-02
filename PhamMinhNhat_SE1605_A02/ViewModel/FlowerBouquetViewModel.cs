using BusinessObjects.Models;
using DataAccess.Repository.FlowerBouquetRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FlowerBouquetViewModel
    {
        public FlowerBouquetViewModel()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int FlowerBouquetId { get; set; }
        public int CategoryId { get; set; }
        public string FlowerBouquetName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public byte? FlowerBouquetStatus { get; set; }
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
