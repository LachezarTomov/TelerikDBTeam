namespace JsonReporter
{
    using System;

    public class JsonReport
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public int TotalQuantitySold { get; set; }

        public decimal ByingPrice { get; set; }

        public DateTime ReportStartDate { get; set; }

        public DateTime ReportEndDate { get; set; }

        public override int GetHashCode()
        {
            return ProductName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            JsonReport C = obj as JsonReport;
            return C != null && String.Equals(this.ProductName, C.ProductName);
        }
    }
}
