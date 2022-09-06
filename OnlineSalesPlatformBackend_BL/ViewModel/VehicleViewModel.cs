using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSalesPlatformBackend_BL.ViewModel
{
    public class VehicleViewModel
    {
        public int VehicleNo { get; set; }
        public string VehicleRunningNo { get; set; }
        public Nullable<int> VModel { get; set; }
        public Nullable<int> SiteNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EDCDate { get; set; }
        public Nullable<int> Supervisor { get; set; }
        public string CurrentStage { get; set; }
    }
}
