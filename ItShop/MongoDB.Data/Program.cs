namespace MongoDB.Data
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver;

    using MongoDB.Model;


    public class Program
    {
        static void Main()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();
            var database = server.GetDatabase("ItShop");

            var seeder = new MongoDataSeeder();

            if (!database.CollectionExists("Manufacturers"))
            {
               database.CreateCollection("Manufacturers"); 
            }
            if (!database.CollectionExists("Stores"))
            {
               database.CreateCollection("Stores"); 
            }
            if (!database.CollectionExists("Products"))
            {
               database.CreateCollection("Products"); 
            }
            if (!database.CollectionExists("Sales"))
            {
               database.CreateCollection("Sales"); 
            }

           // Id = ObjectId.GenerateNewId().ToString();
            
            //TODO: Serializer!?!!?
            MongoDataSeeder.ManufacturerSeeder();
           // var inserter = new MongoDataInserter();
            
           // var manufacturersCollection = database.GetCollection("Manufacturers");

            //Manufacturer[] manufacturersToInsert = {
            //                 new Manufacturer("Dell Inc.", "Worldwide leader in computer development", "Michael Dell"),
            //                 new Manufacturer("Hewlett-Packard", "Worldwide leader in hardware, software and services", "Meg Whitman"),
            //                 new Manufacturer("IBM Inc.", "Worldwide leader in computer development", "Michael Dell"),
            //                 new Manufacturer("Toshiba Corporation", "Worldwide leader in engineering and electronics conglomerate", "Hisao Tanaka"),
            //                 new Manufacturer("ASUSTeK Computer Inc.", "Computer hardware and electronics company", "Jonney Shih"),
            //                 new Manufacturer("Lenovo Group Ltd.", "Leader in computer technology", "Yang Yuanqing"),
            //                 new Manufacturer("Micro-Star International Co., Ltd (MSI)", "Large information technology manufacturer", "Xu Xiang"),
            //                 new Manufacturer("Apple Inc.", "Worldwide leader in consumer electronics, computer software, online services, and personal computers", "Tim Cook"),
            //                 new Manufacturer("Acer Inc.", "Leader in hardware and electronics corporation", "Stan Shih"),
            //                 new Manufacturer("Sony Corporation", "Worldwide leader in electronics, game, entertainment", "Kazuo Hirai")
            //             };

            //manufacturersCollection.InsertBatch(manufacturersToInsert);
           // manufacturersCollection.Insert(new Manufacturer("Dell Inc.", "Worldwide leader in computer development", "Michael Dell"));
            //inserter.AddManufacturer(new Manufacturer("Dell Inc.", "Worldwide leader in computer development", "Michael Dell"));

            
        }
    }
}
