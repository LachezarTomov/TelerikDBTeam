using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace SQLiteManager
{
    public class SQLiteReader
    {
        public IDictionary<string, decimal> GetProductsMarge()
        {
            string pathToSQLightDb = "..\\..\\..\\..\\InputFiles\\ItShop.db";
            SQLiteConnection dbConnection = new SQLiteConnection("Datasource=" + pathToSQLightDb + ";Version=3");
            dbConnection.Open();
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

            using (dbConnection)
            {
                SQLiteCommand selectCommand = new SQLiteCommand
                ("SELECT ProductName, MargePercent FROM ProductsMarge;", dbConnection);
                SQLiteDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    decimal margePercent = (decimal)reader["MargePercent"];

                    dict.Add(productName, margePercent);
                }
                reader.Close();
            }

            return dict;
        }
    }
}
