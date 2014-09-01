namespace MongoDB.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Product
    {

        [BsonConstructor]

        public Product(string name, string category, string manufacturer, decimal price)
        {
            this.ProductName = name;
            this.Category = category;
            this.Manufacturer = manufacturer;
            this.Price = price;
        }

        [BsonId]
        public ObjectId ProductID { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("ProductID: {0}, Category: {1}, Manufacturer {2}, Price {3}", this.ProductName, this.Category, this.Manufacturer, this.Price);
        }

    }
}
