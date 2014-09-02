﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Data.Entity;
using MongoDB.Driver;
using MongoDB.Bson;

using ItShop.Data;
using ItShop.Model;
using ItShop.Data.Migrations;
using ExcelManager;
using XMLManager;
using ZipFileManager;

namespace ItShop.ConsoleClient
{
    public class ItShopConsoleClient
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ItShopDbContext, Configuration>());
            var db = new ItShopDbContext();
            //FillData();
            /* 
             * TEST MILAN
             */

   //         ExcelManager.ExcelReader.ReadFromExcel2003File();
   //         ExcelWriter.CreateExcel2007PlusFile();
            /*
             * END OF TESTS
             */ 
            //DateTime fromDate = new DateTime(2014, 8, 30, 0, 0, 0);
            //DateTime toDate = new DateTime(2014, 9, 30, 23, 59, 59);

            //XMLWriter xmlWriter = new XMLWriter();
            //xmlWriter.SaveSalesReportToXML(fromDate, toDate, "report.xml");

            ZipExcelParser parserFromExcel = new ZipExcelParser(db);
            IList<Sale> sales = parserFromExcel.LoadData();// to load data to the server tomorrow

            foreach (var sale in sales)
            {
                Console.Write("Store id:" + sale.StoreId);
                Console.Write("Sale date:" + sale.SaleDate);
                Console.WriteLine();
                foreach (var saleDetail in sale.SaleDetails)
                {
                    Console.Write("Price: " + saleDetail.SalePrice + " ");
                    Console.Write("Quantity: " + saleDetail.Quantity + " ");
                    Console.WriteLine();
                }

            }


            // Load XML File to save in MSSQL DB
          //  IList<Store> expensesList =  xmlParser.LoadXml("expenses.xml");

            //foreach (var item in expensesList)
            //{
            //    var checkIfExist = db.StoresExpenses
            //        .Where(x => x.ForDate.Year == item.ForDate.Year &&
            //            x.ForDate.Month == item.ForDate.Month).Count();

            //    if (checkIfExist <= 0)
            //    {
            //        db.StoresExpenses.Add(item);
            //    }
            //}

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    Console.WriteLine(e.Message);

            //    foreach (var item in e.EntityValidationErrors)
            //    {
            //        foreach (var err in item.ValidationErrors)
            //        {
            //            Console.WriteLine(err.ErrorMessage);
            //        }
            //    }
            //}
        }

        private void FillStoresExpensesInMongoDB(IList<StoresExpenses> expensesList)
        {
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("StoreExpensesReports");

            MongoCollection<BsonDocument> expensesReports = db.GetCollection<BsonDocument>("ExpensesReports");

            foreach (var expense in expensesList)
            {
                BsonDocument document = new BsonDocument {
                    { "StoreId", expense.StoreId },
                    { "ForDate", expense.ForDate },
                    { "Amount", expense.Amount.ToString() }
                };

                expensesReports.Insert(document);
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
