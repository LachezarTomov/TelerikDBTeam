using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItShop.MySql
{
    public class ProductReport
    {
        public int ProductReportID { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public DateTime ReportStartDate { get; set; }

        public DateTime ReportEndDate  { get; set; }

        public int TotalQuantitySold { get; set; }
    }
}
