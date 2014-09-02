using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManager
{
    public static class ExcelReader
    {

        public static DataTable GetXLSFileFirstTable(string filePath)
        {
            DataSet sheet1 = new DataSet();
            OleDbConnectionStringBuilder conString = new OleDbConnectionStringBuilder();
            conString.Provider = "Microsoft.ACE.OLEDB.12.0";
            conString.DataSource = filePath;
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

            DataTable table = sheet1.Tables[0];

            return table;
        }

        public static void ReadFromExcel2003File()
        {
            var connectionString =
                 @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                 @"Data Source=..\\..\\..\\e062003.xls;Extended Properties=Excel 12.0;Persist Security Info=False";
            OleDbConnection dbCon = new OleDbConnection(connectionString);
            dbCon.Open();
            
            using (dbCon)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM  [E06$]", dbCon);
                OleDbDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Name"] + " " + reader["Score"]);
                    }
                }
            }
        }

        public static void ReadFromExcel2007PlusFile()
        {
            throw new NotImplementedException("ReadFromExcel2007PlusFile");
        }

    }
}