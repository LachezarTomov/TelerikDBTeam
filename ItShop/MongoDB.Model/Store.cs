namespace MongoDB.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Store
    {
        public Store(string name, string address, string town)
        {
           // this.StoreID = ObjectId.GenerateNewId().ToString();
            this.StoreName = name;
            this.Address = address;
            this.Town = town;     
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreID { get; set; }

        public string StoreName { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public override string ToString()
        {
            return this.StoreName + " " + this.Address + " " + this.Town;
        } 
    }
}
