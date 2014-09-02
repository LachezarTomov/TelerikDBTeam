namespace ZipFileManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;
    using System.Data;
    using System.Data.OleDb;

    using ItShop.Model;
    using ItShop.Data;
    using System.Data.Entity;
    using ItShop.Data.Migrations;
    using ExcelManager;

    public class ZipExcelParser
    {
        private string DIRECTORY_ROOT = @"..\..\..\InputDataFiles";  
        private const string FilePattern = "*.xls*";

        public ZipExcelParser(ItShopDbContext db)
        {
            this.DataBase = db;
        }

        public ItShopDbContext DataBase { get; set; }

        public IList<Sale> LoadData()
        {
            String[] AllFiles = this.GetAllFilesFromDirectory();
            IList<Sale> sales = new List<Sale>();

            foreach (var filePath in AllFiles)
            {
                FileInfo fInfo = new FileInfo(filePath);
                String dirNameDate = fInfo.Directory.Name;
                DataTable currentExcelTable = ExcelReader.GetXLSFileFirstTable(filePath);
                var sale = CreateSaleObjectFromDataTable(currentExcelTable, dirNameDate);
                sales.Add(sale);
            }

            return sales;
        }

        private String[] GetAllFilesFromDirectory()
        {
            //UnzipFile();
            String[] allfiles = Directory.GetFiles(DIRECTORY_ROOT, FilePattern, SearchOption.AllDirectories);
            return allfiles;
        }


        private Sale CreateSaleObjectFromDataTable(DataTable table, string dirNameDate)
        {

            string shopName = table.Columns[0].ColumnName;

            int findStoreWithMatchingTableName = this.DataBase.Stores.First(st => st.StoreName.Equals(shopName)).StoreId;

            var currentSale = new Sale
            {
                SaleDate = Convert.ToDateTime(dirNameDate),
                StoreId = findStoreWithMatchingTableName,
            };

            for (int j = 1; j < table.Rows.Count; j++)
            {
                var tableShits = table.Rows[j].ItemArray;
                int ProductID = int.Parse(tableShits[0].ToString());
                int Quantity = int.Parse(tableShits[1].ToString());
                decimal UnitPrice = decimal.Parse(tableShits[2].ToString());

                var currentSaleDetail = new SaleDetail
                {
                    ProductId = ProductID,
                    Quantity = Quantity,
                    SalePrice = UnitPrice
                };

                currentSale.SaleDetails.Add(currentSaleDetail);
            }

            return currentSale;
        }

        private void UnzipFile()
        {
            ZipFile.ExtractToDirectory(DIRECTORY_ROOT + "\\Sale-Reports.zip", DIRECTORY_ROOT);
        }
    }
}
