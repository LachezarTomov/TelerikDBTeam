
namespace MongoDB.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Driver;

    using MongoDB.Model;

    public class MongoDataReader
    {
        private MongoDatabase database;

        public MongoDataReader()
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            this.database = mongoServer.GetDatabase("ItShop");
        }

        public IEnumerable<Store> GetStores()
        {
            var storesCollection = this.database.GetCollection("Stores");
            var allStores = storesCollection.FindAllAs<Store>();
            var storesList = allStores.ToList();

            return storesList;
        }

        public IEnumerable<Product> GetProducts()
        {
            var productsCollection = this.database.GetCollection("Products");
            var allProducts = productsCollection.FindAllAs<Product>();
            var productsList = allProducts.ToList();

            return productsList;
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            var manufacturersCollection = this.database.GetCollection("Manufacturers");
            var allManufacturers = manufacturersCollection.FindAllAs<Manufacturer>();
            var manufacturersList = allManufacturers.ToList();

            return manufacturersList;
        }

        public IEnumerable<Sale> GetSales()
        {
            var salesCollection = this.database.GetCollection("Sales");
            var allSales = salesCollection.FindAllAs<Sale>();
            var salesList = allSales.ToList();

            return salesList;
        }
    }
}
