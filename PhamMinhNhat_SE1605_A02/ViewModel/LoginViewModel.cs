using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LoginViewModel
    {
        public int CustomerId { get; set; }
        public string Email { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
