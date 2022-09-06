using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.ViewModel
{
    public class CustomerCartViewModel
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
