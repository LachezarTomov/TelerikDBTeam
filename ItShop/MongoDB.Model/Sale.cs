namespace MongoDB.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Sale
    {
        public Sale(string store, string product, int quantity, decimal salePrice, BsonDateTime date)
        {
          //  this.SaleID = ObjectId.GenerateNewId().ToString();
            this.Store = store;
            this.Product = product;
            this.Quantity = quantity;
            this.SalePrice = salePrice;
            this.Date = date;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        //public string SaleID { get; set; }

        public string Store { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal SalePrice { get; set; }

        public BsonDateTime Date { get; set; }

        public override string ToString()
        {
            //TODO: to see if reequired
            return base.ToString();
        }
    }
}
