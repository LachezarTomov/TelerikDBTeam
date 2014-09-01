using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItShop.Model;
using System.Xml;


namespace ItShop.ConsoleClient
{
    public class XMLParser
    {
        public void SaveSalesReportToXML(ICollection<Sale> sales, string fileName)
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var sale in sales)
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
        public IList<Store> LoadXml(string fileName)
        {
            var listOfStores = new List<Store>();

            using (XmlReader reader = XmlReader.Create(fileName))
            {
                Store store;
                int idStore = 0;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if(reader.Name == "store")
                        {

                        }
                    }
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        Console.WriteLine(reader.Name + " " + reader.Value + " " + reader.NodeType);

                        switch (reader.Name)
                        {
                            case "store":
                                idStore = Convert.ToInt32(reader.GetAttribute("id"));
                                break;
                            case "expenses":
                                store = new Store();
                                string[] readedDate = reader.GetAttribute("date").Split(new char[] { '.' });
                                int year = Convert.ToInt32(readedDate[1]);
                                int month = Convert.ToInt32(readedDate[0]);
                              //  store.ForDate = new DateTime(year, month, 1);
                               // store.StoreId = idStore;
                                                                
                                //if (reader.Read())
                                //{
                                //    store.Amount = Convert.ToDecimal(reader.Value);
                                //}
                                
                                //listOfStores.Add(store);

                                break;
                        }
                    }
                }
            }

            return listOfStores;
        }
    }
}
