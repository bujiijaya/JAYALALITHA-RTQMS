using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.ViewModel
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int Product { get; set; }
        public int Qty { get; set; }
    }
}
