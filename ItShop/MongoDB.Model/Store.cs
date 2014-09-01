namespace MongoDB.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Store
    {
        [BsonConstructor]
        public Store(string name, string address, string town)
        {
            this.StoreName = name;
            this.Address = address;
            this.Town = town;     
        }

        [BsonId]
        public ObjectId StoreID { get; set; }

        public string StoreName { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public override string ToString()
        {
            return this.StoreName + " " + this.Address + " " + this.Town;
        }
 
    }
}
