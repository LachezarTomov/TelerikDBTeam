using ItShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLManager
{
    public class XMLReader
    {
        string pathToXmlFile = "..\\..\\";
        public IList<Store> LoadStoreReportsFromXml(string fileName)
        {
            var listOfStores = new List<Store>();

            using (XmlReader reader = XmlReader.Create(pathToXmlFile+fileName))
            {
                Store store = new Store();
                int idStore = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "store")
                        {
                            listOfStores.Add(store);
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        //Console.WriteLine(reader.Name + " " + reader.Value + " " + reader.NodeType);

                        switch (reader.Name)
                        {
                            case "store":
                                idStore = Convert.ToInt32(reader.GetAttribute("id"));
                                store = new Store();
                                store.StoreName = reader.GetAttribute("name");
                                break;
                            case "expenses":
                                StoresExpenses expense = new StoresExpenses();
                                string[] readedDate = reader.GetAttribute("date").Split(new char[] { '.' });
                                int year = Convert.ToInt32(readedDate[1]);
                                int month = Convert.ToInt32(readedDate[0]);
                                expense.ForDate = new DateTime(year, month, 1);
                                expense.StoreId = idStore;


                                if (reader.Read())
                                {
                                    expense.Amount = Convert.ToDecimal(reader.Value);
                                }

                                store.Expenses.Add(expense);

                                break;
                        }
                    }
                }
            }

            return listOfStores;
        }
    }
}
