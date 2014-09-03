namespace MongoDB.Data
{
    using System;
    using System.Linq;
    using MongoDB.Driver;

    public class MongoDataMain
    {
        static void Main()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();
            var database = server.GetDatabase("ItShop");

            var seeder = new MongoDataSeeder();

           # region commented and working methods to be redistributed
            /// <summary>
            /// Methods for generating tables in the MongoDB 
            /// </summary>

            //if (!database.CollectionExists("Manufacturers"))
            //{
            //    database.CreateCollection("Manufacturers");
            //}
            //if (!database.CollectionExists("Stores"))
            //{
            //    database.CreateCollection("Stores");
            //}
            //if (!database.CollectionExists("Products"))
            //{
            //    database.CreateCollection("Products");
            //}
            //if (!database.CollectionExists("Sales"))
            //{
            //    database.CreateCollection("Sales");
            //}

            /// <summary>
            /// Methods for filling the MongoDB tables
            /// </summary>
            /// <note>
            /// Comment out after data is seeded!
            /// </note>

            //MongoDataSeeder.ManufacturerSeeder();
            //MongoDataSeeder.ProductSeeder();
            //MongoDataSeeder.StoreSeeder();

            //var reader = new MongoDataReader();

            //var products = reader.GetProducts();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product);
            //}

            //var stores = reader.GetStores();
            //foreach (var store in stores)
            //{
            //    Console.WriteLine(store);
            //}

            //var manufacturers = reader.GetManufacturers();
            //foreach (var manufacturer in manufacturers)
            //{
            //    Console.WriteLine(manufacturer);
            //}
           #endregion

           MongoDataConverter.ConvertData();
        }
    }
}
