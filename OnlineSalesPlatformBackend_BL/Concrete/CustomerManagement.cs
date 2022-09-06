using OnlineSalesPlatformBackend_BL.ViewModel;
using OnlineSalesPlatformBackend_DL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.Concrete
{
    public class CustomerManagement
    {
        private RTQMSEntities dbConnection = new RTQMSEntities();
        public LoginViewModel ValidateCustomer(LoginViewModel loginDetails)
        {
            var results = dbConnection.tbl_Users.Where(c => c.Email == loginDetails.Email && c.Password == loginDetails.Password).FirstOrDefault();
            if (results != null && results.UserId > 0)
            {
                return new LoginViewModel { FullName = results.FirstName + " " + results.LastName, CustomerId = results.UserId, Email = results.Email, Role=results.Role };
            }
            else
            {
                return new LoginViewModel { };
            }

        }

        public CustomerViewModel GetCustomerDetails(int customerID)
        {
            var customerData = dbConnection.tbl_CustomerProfile.Where(c => c.SysUserId == customerID).Select(c => new CustomerViewModel
            {
                CustomerId = c.CustomerID,
                FullName = c.FirstName + " " + c.LastName,
                Email = c.Email,
                Address = c.tbl_CustomerAddressDetails.FirstOrDefault().Address1,
                State = c.tbl_CustomerAddressDetails.FirstOrDefault().State,
                City = c.tbl_CustomerAddressDetails.FirstOrDefault().City,
                Zip = c.tbl_CustomerAddressDetails.FirstOrDefault().PinCode
            }).FirstOrDefault();

            return customerData;
        }

        public List<UserViewModel> GetUsersByRole(string role)
        {
            var customerData = dbConnection.tbl_Users.Where(c => c.Role == role).Select(c => new UserViewModel
            {
                 UserId=c.UserId ,
                FirstName  = c.FirstName ,
                LastName =c.LastName ,
                Email = c.Email,
                MobileNumber  = c.MobileNumber
            }).ToList();

            return customerData.ToList();
        }

        public int SaveCustomerTransaction(tbl_CustomerTransactions transaction)
        {
            var newTransaction = new tbl_CustomerTransactions
            {
                CustomerId = transaction.CustomerId,
                NoofProducts = transaction.NoofProducts,
                TransactionAmount = transaction.TransactionAmount,
                TransactionDate = DateTime.Now,
                TransactionId = 0,
                TransactionStatus = transaction.TransactionStatus
            };
            dbConnection.tbl_CustomerTransactions.Add(newTransaction);
            dbConnection.SaveChanges();
            return 0;

        }

        /// <summary>
        /// To save or update the product details
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int SaveCustomer(UserViewModel user)
        {
            var newUser = new tbl_Users
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role=user.Role,
                IsActive = true,
                MobileNumber = user.MobileNumber,
                Password = user.Password,
                CreatedOn = Convert.ToDateTime(user.CreatedOn),
                UpdatedOn = Convert.ToDateTime(user.UpdatedOn)
            };
            dbConnection.tbl_Users.Add(newUser);
            dbConnection.SaveChanges();
            int maxUserId=dbConnection.tbl_Users.Max(u=>u.UserId);
            var newCustmer = new tbl_CustomerProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = "",
                IsActive = true,
                MobileNumber = user.MobileNumber,
                Password = user.Password,
                SysUserId = maxUserId,
                CreatedON = Convert.ToDateTime(user.CreatedOn),
                UpdatedOn = Convert.ToDateTime(user.UpdatedOn)
            };
            dbConnection.tbl_CustomerProfile.Add(newCustmer);
            dbConnection.SaveChanges();
            return 0;

        }

    }
}
