using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telerik.OpenAccess;
using System.IO;

namespace ItShop.MySql
{
    public static class MySqlManager
    {
        public static void InsertIntoMySql(string path)
        {
            List<ProductReport> reportList= new List<ProductReport>();

            using(var sr = new StreamReader("..\\..\\"+path))
            {
                var currentLine = sr.ReadLine();
                while(currentLine != null)
                {
                    var newReport = JsonConvert.DeserializeObject<ProductReport>(currentLine);
                    reportList.Add(newReport);
                    currentLine = sr.ReadLine();
                }
            }

            using (var context = new ItShopMySql())
            {
                foreach (var report in reportList)
                {
                    context.Add(report);
                }
                context.SaveChanges();
            }
        }

        public static void UpdateDatabase()
        {
            using (var context = new ItShopMySql())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
