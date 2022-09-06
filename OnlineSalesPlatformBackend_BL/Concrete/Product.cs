using OnlineSalesPlatformBackend_BL.Abstract;
using OnlineSalesPlatformBackend_BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSalesPlatformBackend_DL.DBModel;
using System.Data.Common;

namespace OnlineSalesPlatformBackend_BL.Concrete
{
    public class Product : IProduct
    {
        private RTQMSEntities dbConnection = new RTQMSEntities();

        /// <summary>
        /// To get all products from database
        /// </summary>
        /// <returns></returns>
        public List<ProductViewModel> GetAllProducts()
        {
            //Logic has to be implemented
            var allproudcts = new List<ProductViewModel>();
            var results = dbConnection.Sp_GetAllProducts();

            allproudcts = results.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Category = p.Category.ToString(),
                SKU = p.SKU,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                IsActive = p.IsActive,
                CreatedOn = p.CreatedOn,
                Description = "ProductId: " + p.SKU + Environment.NewLine + "Product:" + p.ProductName + Environment.NewLine + "Unit Price: " + p.UnitPrice + Environment.NewLine + "Stock Available: " + p.UnitsInStock + Environment.NewLine + "Add to Cart: " + "https://qrcoderetail.com/buyproduct/" + Environment.NewLine + "View Details: " + "http://qrcoderetail.com/viewproduct"

            }).ToList();

            //allproudcts = ;

            return allproudcts;
        }

        /// <summary>
        /// To get only selected category products
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<ProductViewModel> GetProductsById(int category)
        {

            var proudcts = new List<ProductViewModel>();
            var results = dbConnection.Sp_GetProductsByCategory(category);

            proudcts = results.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Category = p.Category.ToString(),
                SKU = p.SKU,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                IsActive = p.IsActive,
                CreatedOn = p.CreatedOn,
                Description = "Product:" + p.ProductName + Environment.NewLine + "Unit Price: " + p.UnitPrice + Environment.NewLine + "Add to Cart: " + "https://qrcoderetail.com/buyproduct/"

            }).ToList();

            return proudcts;
        }

        /// <summary>
        /// To get only selected category products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductViewModel GetProductDetails(int productId)
        {

            var proudct = new ProductViewModel();
            var p = dbConnection.tbl_Product.Where(pr => pr.ProductId == productId).FirstOrDefault();
            if (p != null)
            {
                proudct = new ProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category.ToString(),
                    SKU = p.SKU,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    IsActive = p.IsActive,
                    CreatedOn = p.CreatedOn,                    
                    Description = "Product:" + p.ProductName + Environment.NewLine + "Unit Price: " + p.UnitPrice + Environment.NewLine + "Add to Cart: " + "https://qrcoderetail.com/buyproduct/"

                };

            }

            return proudct;
        }


        /// <summary>
        /// To save or update the product details
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int SaveProduct(ProductViewModel product)
        {
            var newProduct = new tbl_Product
            {
                ProductName = product.ProductName,
                Category = Convert.ToInt32(product.Category),
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                SKU = product.SKU,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                CreatedOn = Convert.ToDateTime(product.CreatedOn),
                UpdatedOn = Convert.ToDateTime(product.CreatedOn),               

            };
            dbConnection.tbl_Product.Add(newProduct);
            dbConnection.SaveChanges();
            return 0;

        }

        /// <summary>
        /// To toggle the product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool ToggleProduct(int productId)
        {
            var product = dbConnection.tbl_Product.Where(p => p.ProductId == productId).FirstOrDefault();
            var currentState = product.IsActive;
            product.IsActive = !currentState;

            dbConnection.tbl_Product.Add(product);
            dbConnection.Entry(product).State = System.Data.Entity.EntityState.Modified;
            dbConnection.SaveChanges();
            return true;
        }

        private void TestLINQ()
        {
            //Select* from tbl_Product
            var result = from p in dbConnection.tbl_Product select p;

            var resultlambda = dbConnection.tbl_Product;

            //select * from tbl_Product where Category=1
            var result1 = from p in dbConnection.tbl_Product where p.Category == 1 select p;
            var result1lambda = dbConnection.tbl_Product.Where(p => p.Category == 1);
        }
    }
}
