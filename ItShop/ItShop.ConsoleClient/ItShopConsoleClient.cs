using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Data.Entity;
using MongoDB.Driver;
using MongoDB.Bson;

using ItShop.Data;
using ItShop.Model;
using ItShop.Data.Migrations;
using ItShop.Data.MySql;
using ExcelManager;
using XMLManager;
using ZipFileManager;
using PDFManager;

namespace ItShop.ConsoleClient
{
    public class ItShopConsoleClient
    {
        public static void LoadDataToDbForTesting(ItShopDbContext context)
        {
            var Sofia = new Town
            {
                TownName = "Sofia"
            };
            //adreses
            var Address1 = new Address
            {
                AddressName = "Mladost 1 Telerik"
            };
            var Address2 = new Address
            {
                AddressName = "Maria Luiza 123",
            };
            //stores

            Sofia.Addresses.Add(Address1);
            Sofia.Addresses.Add(Address2);
            var Store1 = new Store
            {
                StoreName = "Laptop.bg"
            };

            var Store2 = new Store
            {
                StoreName = "Most Computers"
            };

            var Store3 = new Store
            {
                StoreName = "PIC Computers"
            };

            var Store4 = new Store
            {
                StoreName = "PCStore.bg"
            };

            var Store5 = new Store
            {
                StoreName = "Most Computers - Easy Office"
            };

            Address1.Stores.Add(Store1);
            Address1.Stores.Add(Store2);
            Address1.Stores.Add(Store3);
            Address2.Stores.Add(Store4);
            Address2.Stores.Add(Store5);
            //Categoories
            var Categori1 = new Category
            {
                CategoryName = "Laptop"
            };
            var Categori2 = new Category
            {
                CategoryName = "Tablet"
            };
            var Categori3 = new Category
            {
                CategoryName = "Mobifon"
            };
            context.Towns.Add(Sofia);
            context.Categories.Add(Categori1);
            context.Categories.Add(Categori2);
            context.Categories.Add(Categori3);
            //manufacturer
            var manufacturer = new Manufacturer
            {
                ManufacturerName = "Fujitsu",
                Description = "Best pc in the world",
                CEO = "Malkiq muk"
            };
            context.Manufacturers.Add(manufacturer);
            //Products
            var product1 = new Product
            {
                ProductName = "Samsung Galaxy",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product2 = new Product
            {
                ProductName = "Ifon5",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product3 = new Product
            {
                ProductName = "Samsung Galaxy2",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product4 = new Product
            {
                ProductName = "Samsung Galaxy4",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product5 = new Product
            {
                ProductName = "Samsung Galaxy5",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product6 = new Product
            {
                ProductName = "Samsung Galaxy6",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product7 = new Product
            {
                ProductName = "Samsung Galaxy6",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product8 = new Product
            {
                ProductName = "Samsung Galaxy6",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product9 = new Product
            {
                ProductName = "Samsung Galaxy6",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            var product10 = new Product
            {
                ProductName = "Samsung Galaxy6",
                BuyingPrice = 19m,
                BasePrice = 12m,
                ManufacturerId = 1,
                CategoryId = 1
            };
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);
            context.Products.Add(product6);
            context.Products.Add(product7);
            context.Products.Add(product8);
            context.Products.Add(product9);
            context.Products.Add(product10);


            context.SaveChanges();
        }

        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ItShopDbContext, Configuration>());
            
            var db = new ItShopDbContext();

           // LoadDataToDbForTesting(db);
           // db.SaveChanges();

            PDFReporter pdfReporter = new PDFReporter(db);
            DateTime[] dates = new DateTime[] { new DateTime(2013, 7, 20), new DateTime(2013, 7, 21), new DateTime(2013, 7, 22) };
            pdfReporter.GeneratePdfSalesReport("pdfTest", dates);
            //TEST pdf reporter


            //FillData();
            /* 
             * TEST MILAN
             */

         //   MysqlManager.UpdateDatabase();
   //         ExcelManager.ExcelReader.ReadFromExcel2003File();
   //         ExcelWriter.CreateExcel2007PlusFile();
            /*
             * END OF TESTS
             */ 
            //DateTime fromDate = new DateTime(2014, 8, 30, 0, 0, 0);
            //DateTime toDate = new DateTime(2014, 9, 30, 23, 59, 59);

            //XMLWriter xmlWriter = new XMLWriter();
            //xmlWriter.SaveSalesReportToXML(fromDate, toDate, "report.xml");

            //ZipExcelParser parserFromExcel = new ZipExcelParser(db);
            //IList<Sale> sales = parserFromExcel.LoadData();// to load data to the server tomorrow

            //foreach (var sale in sales)
            //{
            //    db.Sales.Add(sale);
            //    //Console.Write("Store id:" + sale.StoreId);
            //    //Console.Write("Sale date:" + sale.SaleDate);
            //    //Console.WriteLine();
            //    //foreach (var saleDetail in sale.SaleDetails)
            //    //{
            //    //    Console.Write("Price: " + saleDetail.SalePrice + " ");
            //    //    Console.Write("Quantity: " + saleDetail.Quantity + " ");
            //    //    Console.WriteLine();
            //    //}
            //}
            //db.SaveChanges();
            // Load XML File to save in MSSQL DB
            //XMLReader xmlReader = new XMLReader();
            
            //// Load data XML data in MSSQL
            //IList<Store> expensesList = xmlReader.LoadStoreReportsFromXml("expenses.xml");
            //SaveExpensesReportsInMSSQL(expensesList, db);

            //FillStoresExpensesInMongoDB(expensesList);
        }

        private static void SaveExpensesReportsInMSSQL(IList<Store> storesList, ItShopDbContext db)
        {
           // var db = new ItShopDbContext();
           // using (db)
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

        private static void FillStoresExpensesInMongoDB(IList<Store> stores)
        {
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("ItShop");

            MongoCollection<BsonDocument> expensesReports = db.GetCollection<BsonDocument>("ExpensesReports");

            foreach (var store in stores)
            {
                expensesReports.Insert(store);
            }
        }
            
       

        private static void FillData()
        {
            var db = new ItShopDbContext();
            var store = new Store { StoreName = "Main store" };
            db.Stores.Add(store);
            db.SaveChanges();

            var product1 = new Product { ProductName = "Laptop HP 556 Cromebook", BasePrice = 1024.20m };
            var product2 = new Product { ProductName = "Laptop HP 6T Elitebook", BasePrice = 489.00m };
            var product3 = new Product { ProductName = "Laptop Toshiba Satellite C50-B-14", BasePrice = 620.00m };

            db.Products.Add(product1);
            db.Products.Add(product2);
            db.Products.Add(product3);
            db.SaveChanges();

            var sale = new Sale
            {
                StoreId = store.StoreId,
                SaleDate = DateTime.Now
            };

            sale.SaleDetails.Add(new SaleDetail
            {
                ProductId = product1.ProductId,
                Quantity = 1,
                SalePrice = product1.BasePrice * 1.2m
            });

            sale.SaleDetails.Add(new SaleDetail
            {
                ProductId = product3.ProductId,
                Quantity = 2,
                SalePrice = product3.BasePrice
            });

            db.Sales.Add(sale);
            db.SaveChanges();
        }
    }
}
