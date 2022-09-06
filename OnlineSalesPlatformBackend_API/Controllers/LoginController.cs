using OnlineSalesPlatformBackend_BL.Concrete;
using OnlineSalesPlatformBackend_BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineSalesPlatformBackend_API.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
       

        // POST: api/Login
        [HttpPost]
        public LoginViewModel PostLoginDetails(LoginViewModel userDetails)
        {
            var customerManagement = new CustomerManagement();
            return customerManagement.ValidateCustomer(userDetails);

        }

        [HttpPost]
        public int PostUser(UserViewModel user)
        {
            var customerManagement = new CustomerManagement();
            return customerManagement.SaveCustomer(user);

        }


        public IEnumerable<UserViewModel> GetUsersByRole(int id)
        {
            string role = "Supervisor";
            if (id == 2)
            {
                role = "Engineer";
            }
            var customerManagement = new CustomerManagement();
            return customerManagement.GetUsersByRole(role);
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
