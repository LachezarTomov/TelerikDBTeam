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

    public class ZipExcelParser
    {
        private string DIRECTORY_ROOT = @"C:\Users\Dobri\Desktop\GitProjects\TelerikDBTeam\ItShop\ZipFileManager\bin\Debug";     
        private const string FilePattern = "*.xls*";

        public ZipExcelParser(ItShopDbContext db)
        {
            this.db = db;
            this.AllFiles = this.GetAllFilesFromDirectory();
        }

        public String[] AllFiles { get; set; }
        public ItShopDbContext db { get; set; }

        public IList<Sale> LoadData()
        {
            IList<Sale> sales = new List<Sale>();

            foreach (var filePath in this.AllFiles)
            {
                var date = Path.GetFileName(filePath);
                FileInfo fInfo = new FileInfo(filePath);
                String dirNameDate = fInfo.Directory.Name;//takes dir name for date             
                ReadFileContent(filePath, dirNameDate, sales);
            }

            return sales;
        }

        private String[] GetAllFilesFromDirectory()
        {
           // UnzipFile();
            String[] allfiles = Directory.GetFiles(DIRECTORY_ROOT, FilePattern, SearchOption.AllDirectories);
            return allfiles;
        }

        private void ReadFileContent(string fileName, string dirNameDate, IList<Sale> sales)
        {

            DataSet sheet1 = new DataSet();
            OleDbConnectionStringBuilder conString = new OleDbConnectionStringBuilder();
            conString.Provider = "Microsoft.ACE.OLEDB.12.0";
            conString.DataSource = fileName;
            conString.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            using (OleDbConnection connection = new OleDbConnection(conString.ConnectionString))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sheet1$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.Fill(sheet1);
                }
                connection.Close();
            }

            var table = sheet1.Tables[0];
            string shopName = table.Columns[0].ColumnName;
          //  Console.WriteLine(shopName);

            var findStoreWithMatchingTableName = db.Stores.First(st => st.StoreName.Contains(shopName));//to be fixed should find matching name of the store and the table with report
            //Console.WriteLine(findStoreWithMatchingTableName.StoreId);
          
            var currentSale = new Sale
            {
                SaleDate = Convert.ToDateTime(dirNameDate),
                StoreId = findStoreWithMatchingTableName.StoreId,
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

            sales.Add(currentSale);
        }

        private void UnzipFile()
        {
            ZipFile.ExtractToDirectory(DIRECTORY_ROOT + "\\Sale-Reports.zip", DIRECTORY_ROOT);
        }
    }
}
