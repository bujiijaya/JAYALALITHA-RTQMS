using OnlineSalesPlatformBackend_BL.Concrete;
using OnlineSalesPlatformBackend_BL.ViewModel;
using OnlineSalesPlatformBackend_DL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineSalesPlatformBackend_API.Controllers
{
    public class CartController : ApiController
    {
        private Cart cart = new Cart();
        private CustomerManagement customerMgmnt = new CustomerManagement();
        // GET: api/Cart


        public IEnumerable<CustomerCartViewModel> GetCustomerCart(int id)
        {
            return cart.GetCustomerCart(id);
        }

        public CustomerViewModel GetCustomerDetails(int id)
        {
            return customerMgmnt.GetCustomerDetails(id);
        }

        [HttpGet]
        public int GetRemoveCustomerCart(int id)
        {
            return cart.RemoveProductFromCart(id);
        }

        // GET: api/Cart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        [HttpPost]
        public int AddProductTotheCart(CartViewModel cartDetails)
        {
            return cart.AddProductTotheCart(cartDetails);
        }

        [HttpPost]
        public int SaveCustomerTransaction(tbl_CustomerTransactions transaction)
        {
            return customerMgmnt.SaveCustomerTransaction(transaction);
        }

        // PUT: api/Cart/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
        }
    }
}
