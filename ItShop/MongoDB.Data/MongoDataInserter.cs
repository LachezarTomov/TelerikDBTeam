namespace MongoDB.Data
{
    using MongoDB.Driver;

    using MongoDB.Model;

    public class MongoDataInserter
    {
        private MongoDatabase database;

        public MongoDataInserter()
        {
            var connection = new MongoClient("mongodb://localhost/");
            var server = connection.GetServer();
            this.database = server.GetDatabase("ItShop");
        }

        public void AddStore(Store store)
        {
            var stores = this.database.GetCollection("Stores");
            stores.Insert(store);
        }

        public void AddProduct(Product product)
        {
            var products = this.database.GetCollection("Products");
            products.Insert(product);
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            var manufacturers = this.database.GetCollection("Manufacturers");
            manufacturers.Insert(manufacturer);
        }

        public void AddDealer(Sale sale)
        {
            var sales = this.database.GetCollection("Sales");
            sales.Insert(sale);
        }

    }
}
