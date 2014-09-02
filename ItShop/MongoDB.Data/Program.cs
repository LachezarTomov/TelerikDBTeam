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
            
            //TODO: Serializer!?!!?
            MongoDataSeeder.Seeder();

        }
    }
}
