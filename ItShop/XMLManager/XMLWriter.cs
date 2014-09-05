using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ItShop.Data;
using ItShop.Model;
using System.Text;
using System.Xml;

namespace XMLManager
{
    public class XMLWriter
    {
        private const string PathToXmlFile = @"..\..\..\..\OutputFiles\";

        public void SaveSalesReportToXML(DateTime fromDate, DateTime toDate, string fileName)
        {
            var db = new ItShopDbContext();

            var salesInRange = db.Sales
                .Where(x => x.SaleDate >= fromDate && x.SaleDate <= toDate)
                .ToList();

            Encoding encoding = Encoding.GetEncoding("UTF-8");

            using (XmlTextWriter writer = new XmlTextWriter(PathToXmlFile+fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var sale in salesInRange)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("date", sale.SaleDate.ToShortDateString());
                    foreach (var det in sale.SaleDetails)
                    {
                        writer.WriteStartElement("item");
                        writer.WriteAttributeString("product", det.Product.ProductName);
                        writer.WriteAttributeString("price", det.Product.BasePrice.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndDocument();
            }
        }
    }
}
