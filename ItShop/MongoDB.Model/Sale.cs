namespace MongoDB.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Sale
    {

        [BsonConstructor]
        public Sale(string store, string product, int quantity, decimal salePrice, BsonDateTime date)
        {
            this.Store = store;
            this.Product = product;
            this.Quantity = quantity;
            this.SalePrice = salePrice;
            this.Date = date;
        }

        [BsonId]
        public ObjectId SaleID { get; set; }

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
