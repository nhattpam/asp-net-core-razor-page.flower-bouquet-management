using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            FlowerBouquets = new HashSet<FlowerBouquet>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public virtual ICollection<FlowerBouquet> FlowerBouquets { get; set; }
    }
}
