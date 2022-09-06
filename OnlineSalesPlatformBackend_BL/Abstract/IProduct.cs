using OnlineSalesPlatformBackend_BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.Abstract
{
    interface IProduct
    {
        List<ProductViewModel> GetAllProducts();
        List<ProductViewModel> GetProductsById(int productId);

        int SaveProduct(ProductViewModel product);

        bool ToggleProduct(int productId);


    }
}
