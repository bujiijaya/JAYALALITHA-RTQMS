using OnlineSalesPlatformBackend_BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineSalesPlatformBackend_BL.Concrete;

namespace OnlineSalesPlatformBackend_API.Controllers
{
    public class SiteController : ApiController
    {
        private Site site = new Site();
        // GET: api/Product
        public IEnumerable<SiteViewModel> GetAllSites()
        {
            return site.GetAllSites();
        }

        // GET: api/Product/5
        public IEnumerable<SiteViewModel> GetSitesforSupervisor(int id)
        {
            return site.GetSitesById(id);
        }

        // GET: api/Product/5
        public IEnumerable<VehicleViewModel> GetSiteVehicles(int id)
        {
            return site.GetVehiclesBySiteId(id);
        }

        // GET: api/Product/5
        public ProductViewModel GetProductDetails(int id)
        {
            return site.GetProductDetails(id);
        }

        // POST: api/Product
        [HttpPost]
        public void PostSiteDetails(SiteViewModel siteDetails)
        {
            site.SaveSite(siteDetails);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Product/5
        public void Toggle(int id)
        {
            site.ToggleProduct(id);
        }
    }
}
