using OnlineSalesPlatformBackend_BL.ViewModel;
using OnlineSalesPlatformBackend_DL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.Concrete
{
    public class Cart
    {
        private RTQMSEntities dbConnection = new RTQMSEntities();

        public int AddProductTotheCart(CartViewModel cart)
        {
            int custId = dbConnection.tbl_CustomerProfile.Where(c => c.SysUserId == cart.CustomerId).FirstOrDefault().CustomerID;
            var newCart = new tbl_CustomerCart
            {
                Product = cart.Product,
                CustomerId = custId,
                Qty = cart.Qty
            };
            dbConnection.tbl_CustomerCart.Add(newCart);
            dbConnection.SaveChanges();
            return 1;

        }

        public int RemoveProductFromCart(int cartId)
        {
            //int custId = dbConnection.tbl_CustomerProfile.Where(c => c.SysUserId == cartItem.CustomerId).FirstOrDefault().CustomerID;

            var customerCart = dbConnection.tbl_CustomerCart.Where(c => c.CartId == cartId).FirstOrDefault();
            if (customerCart != null)
            {
                dbConnection.tbl_CustomerCart.Remove(customerCart);
                dbConnection.SaveChanges();
            }           
            return 1;
        }

        public int ClearCart(int customerId)
        {
            var customerCart = dbConnection.tbl_CustomerCart.Where(c => c.CustomerId == customerId).ToList();
            foreach (var cartProduct in customerCart)
            {
                dbConnection.tbl_CustomerCart.Remove(cartProduct);
                dbConnection.SaveChanges();
            }
            return 1;
        }

        public List<CustomerCartViewModel> GetCustomerCart(int customerId)
        {
            var customerCartView = new List<CustomerCartViewModel>();
            //if (customerId > 0)
            //{
            //    int custId = dbConnection.tbl_CustomerProfile.Where(c => c.SysUserId == customerId).FirstOrDefault().CustomerID;

            //    var customerCarts = dbConnection.tbl_CustomerCart.Where(c => c.CustomerId == custId).ToList();

            //    foreach (var customerCart in customerCarts)
            //    {
            //        var productDetails = dbConnection.tbl_Product.Where(p => p.ProductId == customerCart.Product).FirstOrDefault();
            //        customerCartView.Add(new CustomerCartViewModel
            //        {
            //            CartId = customerCart.CartId,
            //            CustomerId = Convert.ToInt32(customerCart.CustomerId),
            //            ProductId = Convert.ToInt32(customerCart.Product),
            //            Qty = Convert.ToInt32(customerCart.Qty),
            //            ProductName = productDetails.ProductName,
                        
            //            UnitPrice = Convert.ToDecimal(productDetails.UnitPrice),
            //            Category = productDetails.tbl_ProductCategory.CategoryName,
            //             Description = "Product:" + productDetails.ProductName + Environment.NewLine + "Unit Price: " + productDetails.UnitPrice + Environment.NewLine + "Click to Buy : " + "http://localhost:4200/bill/"+ customerId


            //        });
            //    }


            //}

            return customerCartView;
        }
    }
}
