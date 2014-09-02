using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManager
{
    public static class ExcelReader
    {
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