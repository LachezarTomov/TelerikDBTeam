namespace ItShop.MySql
{
    using System;

    public class ProductReport
    {
        public int ProductReportID { get; set; }

        public string ProductName { get; set; }

        public decimal BuyingPrice { get; set; }

        public string CategoryName { get; set; }

        public DateTime ReportStartDate { get; set; }

        public DateTime ReportEndDate  { get; set; }

        public int TotalQuantitySold { get; set; }
    }
}
