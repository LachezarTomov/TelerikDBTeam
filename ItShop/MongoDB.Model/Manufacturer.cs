namespace MongoDB.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Manufacturer
    {
        public Manufacturer(string name, string description, string manager)
        {
            //this.ManufacturerID = ObjectId.GenerateNewId().ToString();
            this.ManufacturerName = name;
            this.Description = description;
            this.CEO = manager;
        }

        //[BsonRepresentation(BsonType.ObjectId)]
        //public string ManufacturerID { get; set; }

        public string ManufacturerName { get; set; }

        public string Description { get; set; }

        public string CEO { get; set; }

        public override string ToString()
        {
            return string.Format("ManufacturerID: {0}, Description: {1}, CEO {2}", this.ManufacturerName, this.Description, this.CEO);
        }
    }
}
