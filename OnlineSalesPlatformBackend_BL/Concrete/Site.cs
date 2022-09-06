using OnlineSalesPlatformBackend_BL.ViewModel;
using OnlineSalesPlatformBackend_DL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.Concrete
{
    public class Site
    {
        private RTQMSEntities dbConnection = new RTQMSEntities();

        /// <summary>
        /// To get all products from database
        /// </summary>
        /// <returns></returns>
        public List<SiteViewModel> GetAllSites()
        {
            //Logic has to be implemented
            var allproudcts = new List<SiteViewModel>();
            var results = dbConnection.tbl_Sites.ToList();

            allproudcts = results.Select(p => new SiteViewModel
            {
                SiteId = p.SiteId,
                Address = p.Address,
                ContactEmail = p.ContactEmail,
                ContactNumber = p.ContactNumber,
                SiteLocation = p.SiteLocation,
                SiteName = p.SiteName

            }).ToList();

            //allproudcts = ;

            return allproudcts;
        }

        /// <summary>
        /// To get only selected category products
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<SiteViewModel> GetSitesById(int category)
        {

            var sites = new List<SiteViewModel>();
            int site = Convert.ToInt32(dbConnection.tbl_VehicleRegistration.Where(s => s.Supervisor == category).FirstOrDefault().SiteNo);
            var results = dbConnection.tbl_Sites.Where(s => s.SiteId == site).ToList();

            sites = results.Select(p => new SiteViewModel
            {
                SiteId = p.SiteId,
                Address = p.Address,
                ContactEmail = p.ContactEmail,
                ContactNumber = p.ContactNumber,
                SiteLocation = p.SiteLocation,
                SiteName = p.SiteName

            }).ToList();
            return sites;
        }

        /// <summary>
        /// To get only selected category products
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<VehicleViewModel> GetVehiclesBySiteId(int category)
        {

            var vehicles = new List<VehicleViewModel>();
            var results = dbConnection.tbl_VehicleRegistration.Where(s => s.SiteNo == category).ToList();

            foreach (var v in results)
            {
                int currentStage = Convert.ToInt32(dbConnection.tbl_VehicleStageProgress.Where(vp => vp.VehicleId == v.VehicleNo && vp.Status == "InProgress").FirstOrDefault().StageId);
                var vehicle = new VehicleViewModel
                {
                    VehicleNo = v.VehicleNo,
                    SiteNo = v.SiteNo,
                    Supervisor = v.Supervisor,
                    EDCDate = v.EDCDate,
                    StartDate = v.StartDate,
                    VehicleRunningNo = v.VehicleRunningNo,
                    VModel = v.VModel,
                    CurrentStage = dbConnection.tbl_Stages.Where(s => s.StageId == currentStage).FirstOrDefault().StageName

                };
                vehicles.Add(vehicle);
            }

            return vehicles;
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
        public int SaveSite(SiteViewModel site)
        {
            var newSite = new tbl_Sites
            {
                SiteId = 0,
                Address = site.Address,
                ContactEmail = site.ContactEmail,
                ContactNumber = site.ContactNumber,
                SiteLocation = site.SiteLocation,
                SiteName = site.SiteName

            };
            dbConnection.tbl_Sites.Add(newSite);
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
