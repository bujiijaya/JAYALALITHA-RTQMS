using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineSalesPlatformBackend_BL.Concrete;
using OnlineSalesPlatformBackend_BL.ViewModel;

namespace OnlineSalesPlatformBackend_API.Controllers
{
    public class ProductController : ApiController
    {
        private Product product = new Product();
        // GET: api/Product
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return product.GetAllProducts();
        }

        // GET: api/Product/5
        public IEnumerable<ProductViewModel> GetProuductsByCategory(int id)
        {
            return product.GetProductsById(id);
        }

        // GET: api/Product/5
        public ProductViewModel GetProductDetails(int id)
        {
            return product.GetProductDetails(id);
        }

        // POST: api/Product
        [HttpPost]
        public void PostProductDetails(ProductViewModel productDetails)
        {
            product.SaveProduct(productDetails);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Toggle(int id)
        {
            product.ToggleProduct(id);
        }
    }
}
