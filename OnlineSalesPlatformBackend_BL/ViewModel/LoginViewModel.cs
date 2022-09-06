using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }

        public int CustomerId { get; set; }
        public string Role { get; set; }
    }
}
