using BusinessObjects.Models;
using Repository.CustomerRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
{
    public class CustomerViewModel {

        public CustomerViewModel()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Email { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string? ToString()
        {
            return "Email: " + Email + "Pass: " + Password +
                "Name: " + CustomerName + "Country: " + Country
                + "City: " + City + "Birthday: " + Birthday + "ID: " + CustomerId;
        }
    }
}
