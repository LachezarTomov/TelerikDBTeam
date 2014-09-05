namespace JsonReporter
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ItShop.Data;

    public class JsonReporterer
    {
        private const string PathForJsonPath = @"..\..\..\..\OutputFiles\";
        private const string TextFile = "JsonReport.txt";
        private const string JsonFile = "JsonReport.json";

        public JsonReporterer(ItShopDbContext db)
        {
            this.Dbase = db;
        }

        public ItShopDbContext Dbase { get; set; }

        private HashSet<JsonReport> ProductInStock(DateTime startDate, DateTime endDate)
        {
            List<JsonReport> listOfStocks = new List<JsonReport>();

            Dictionary<string, int> dict = new Dictionary<string, int>();
            HashSet<JsonReport> uniqueReport = new HashSet<JsonReport>();

            var taskList = Dbase.SaleDetails.Where(s => s.Sale.SaleDate >= startDate && s.Sale.SaleDate <= endDate).Select(s => new
            {
                ProductId = Dbase.Products.Where(p => p.ProductId == s.ProductId).FirstOrDefault().ProductId,
                ProductName = Dbase.Products.Where(p => p.ProductId == s.ProductId).FirstOrDefault().ProductName,
                Category = Dbase.Products.Where(p => p.ProductId == s.ProductId).FirstOrDefault().Category.CategoryName,
                AmountSold = s.Quantity,
                Price = s.SalePrice,
                ReportStartDate = s.Sale.SaleDate,
                reportEndDate = s.Sale.SaleDate

            }).ToList();

            foreach (var stock in taskList)
            {
                var newProduct = new JsonReport();
                newProduct.ProductName = stock.ProductName;
                newProduct.CategoryName = stock.Category;
                newProduct.TotalQuantitySold = stock.AmountSold;
                newProduct.ReportStartDate = startDate;
                newProduct.ReportEndDate = endDate;
                newProduct.ByingPrice = stock.Price;
                newProduct.ProductId = stock.ProductId;

                listOfStocks.Add(newProduct);
            }

            foreach (var stock in listOfStocks)
            {
                if (!dict.ContainsKey(stock.ProductName))
                {
                    dict[stock.ProductName] = 0;
                }
                dict[stock.ProductName] += stock.TotalQuantitySold;
            }

            foreach (var stock in listOfStocks)
            {
                stock.TotalQuantitySold = dict[stock.ProductName];
                uniqueReport.Add(stock);
            }

            return uniqueReport;
        }

        private string ConvertJsonReportToJson(JsonReport report)
        {
            return JsonConvert.SerializeObject(report);
        }

        public void WriteJsonReportToTxtFile(DateTime startDate, DateTime endDate)
        {
            HashSet<JsonReport> reports = ProductInStock(startDate, endDate);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(PathForJsonPath + TextFile))
            {
                foreach (JsonReport line in reports)
                {
                    var reportAsString = this.ConvertJsonReportToJson(line);
                    file.WriteLine(reportAsString);
                    using (System.IO.StreamWriter jsonFIle = new System.IO.StreamWriter(PathForJsonPath + line.ProductId.ToString() + JsonFile))
                    {
                        jsonFIle.Write(reportAsString);
                    }
                    
                }
            }
        }
    }
}