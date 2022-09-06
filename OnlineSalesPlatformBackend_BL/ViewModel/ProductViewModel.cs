using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public string Cloth { get; set; }

    }
}
