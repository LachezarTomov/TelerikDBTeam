using ExcelManager;
using ItShop.Data;
using ItShop.Model;
using ItShop.MySql;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using PDFManager;
using ZipFileManager;
using MongoDB.Data;
using JsonReporter;
using SQLiteManager;
using XMLManager;

namespace ItShop.ConsoleClient
{

    public class ItShopConsoleClient
    {
        private static void FillStoresExpensesInMongoDB(IList<Store> storesList)
        {
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("ItShop");

            MongoCollection<Store> expensesReports = db.GetCollection<Store>("ExpensesReports");

            foreach (var store in storesList)
            {
                expensesReports.Insert(store);
            }
        }
    
        private static void SaveExpensesReportsInMssql(IList<Store> storesList, ItShopDbContext db)
        {
            using (db)
            {
                foreach (var store in storesList)
                {
                    var expenses = store.Expenses;
                    foreach (var expense in expenses)
                    {
                        var checkIfExist = db.StoresExpenses
                            .Where(x => x.ForDate.Year == expense.ForDate.Year && x.ForDate.Month == expense.ForDate.Month).Count();

                        if (checkIfExist <= 0)
                        {
                            db.StoresExpenses.Add(expense);
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        private static void E01LoadExcelReportsFromZip(ItShopDbContext db)
        {
            ZipExcelParser parserFromExcel = new ZipExcelParser(db);
            IList<Sale> sales = parserFromExcel.LoadData();

            foreach (var sale in sales)
            {
                db.Sales.Add(sale);
            }

            db.SaveChanges();
        }

        private static void E02GeneratePdfReport(ItShopDbContext db)
        {
            var testPdf = new PDFReporter(db);

            DateTime firstDate = new DateTime(2013, 7, 20, 0, 0, 0);
            DateTime secondDate = new DateTime(2013, 7, 21, 0, 0, 0);
            DateTime thirdDate = new DateTime(2013, 7, 22, 0, 0, 0);
            DateTime forthDate = new DateTime(2013, 7, 23, 0, 0, 0);

            testPdf.GeneratePdfSalesReport("Telerik Sales Report",
                new[] { firstDate, secondDate, thirdDate, forthDate });
        }

        private static void E03GenerateXmlReport(ItShopDbContext db)
        {
            DateTime fromDate = new DateTime(2010, 8, 30, 0, 0, 0);
            DateTime toDate = new DateTime(2014, 9, 30, 23, 59, 59);

            XMLWriter xmlWriter = new XMLWriter();
            xmlWriter.SaveSalesReportToXML(fromDate, toDate, "report.xml");
        }

        private static void E04GenerateJsonFiles(ItShopDbContext db, DateTime startDate, DateTime endDate)
        {
            var jsonReporter = new JsonReporterer(db);
            jsonReporter.WriteJsonReportToTxtFile(startDate, endDate);
        }

        private static void E04LoadJsonToMySql(string path)
        {
            MySqlManager.UpdateDatabase();
            MySqlManager.InsertIntoMySql(path);
        }

        private static void E05LoadDataFromXmlToMssql(ItShopDbContext db)
        {
            XMLReader xmlReader = new XMLReader();
            IList<Store> expensesList = xmlReader.LoadStoreReportsFromXml("expenses.xml");
            SaveExpensesReportsInMssql(expensesList, db);

            // Filling the mangalDB
            FillStoresExpensesInMongoDB(expensesList);
        }

        private static void GenerateExcel2007Report()
        {
            var mySqlContext = new ItShopMySql();
            var sqLiteManager = new SQLiteReader();
            var dictWithMarge = sqLiteManager.GetProductsMarge();
            var allReports = mySqlContext.ProductRepports.Select(pr => pr);

            List<Dictionary<string, string>> finalReports = new List<Dictionary<string, string>>();
            foreach (var report in allReports)
            {
                var newDict = new Dictionary<string, string>();

                var marge = dictWithMarge[report.ProductName];
                var sellingPrice = (report.BuyingPrice + (report.BuyingPrice * marge / 100)).ToString();
                newDict.Add("Product Name", report.ProductName);
                newDict.Add("Category Name", report.CategoryName);
                newDict.Add("From", report.ReportStartDate.ToString());
                newDict.Add("To", report.ReportEndDate.ToString());
                newDict.Add("Total Quantity Sold", report.TotalQuantitySold.ToString());
                newDict.Add("Buying Price", report.BuyingPrice.ToString());
                newDict.Add("Selling Price", sellingPrice);

                finalReports.Add(newDict);
            }

            ExcelWriter.CreateExcel2007PlusFile(finalReports);
        }

        static void Main()
        {
            var db = new ItShopDbContext();
            //MongoDB Seeder
            
           MongoDataConverter.ConvertData();


           E01LoadExcelReportsFromZip(db);
           Console.WriteLine("Ex1 - OK");
           E02GeneratePdfReport(db);
           Console.WriteLine("Ex2 - OK");
           E03GenerateXmlReport(db);
           Console.WriteLine("Ex3 - OK");
           DateTime firstDate = new DateTime(2013, 7, 20, 0, 0, 0);
           DateTime secondDate = new DateTime(2013, 7, 21, 0, 0, 0);
           E04GenerateJsonFiles(db, firstDate, secondDate);
           Console.WriteLine("Ex4 - OK");
           E05LoadDataFromXmlToMssql(db);
           Console.WriteLine("Ex5 - OK");
            GenerateExcel2007Report();
            Console.WriteLine("Ex6 - OK");
            //Console.WriteLine(db.Products.Any()); 
            //FillData();

            //;
         
            // ExctestPelManager.ExcelReader.ReadFromExcel2003File();
           
            // ExcelWriter.CreateExcel2007PlusFile();
    

          
          
        }

        
        }
}
