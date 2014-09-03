namespace MongoDB.Data
{
    using System.Linq;

    using ItShop.Model;
    using ItShop.Data;

    public class MongoDataConverter
    {
        public static void ConvertData()
        {
            var db = new ItShopDbContext();
            var reader = new MongoDataReader();
            using (db)
            {
                ConvertManufacturersData(db, reader);
                //ConvertProductsData(db,reader);
                //ConvertStoresData(db,reader);
                //ConvertSalesData(db,reader);
            }
        }

        private static void ConvertManufacturersData(ItShopDbContext db, MongoDataReader reader)
        {
            var manufacturers = reader.GetManufacturers();

            foreach (var currManufacturer in manufacturers)
            {
                //to check query
                var sqlCurrentManufacturer = db.Manufacturers.Where(m => m.ManufacturerName == currManufacturer.ManufacturerName
                    && m.Description == currManufacturer.Description
                    && m.CEO == currManufacturer.CEO).FirstOrDefault();

                if (sqlCurrentManufacturer == null)
                {
                    var newManufacturer = new ItShop.Model.Manufacturer();
                    newManufacturer.ManufacturerName = currManufacturer.ManufacturerName;
                    newManufacturer.Description = currManufacturer.Description;
                    newManufacturer.CEO = currManufacturer.CEO;
                    db.Manufacturers.Add(newManufacturer);
                }
            }
            db.SaveChanges();
        }

        private static void ConvertProductsData(ItShopDbContext db, MongoDataReader reader)
        {
            var products = reader.GetProducts();

            foreach (var currProduct in products)
            {
                //to check query
                var sqlCurrentProduct = db.Products.Where(p => p.ProductName == currProduct.ProductName);

                if (sqlCurrentProduct == null)
                {
                    var newProduct = new ItShop.Model.Product();
                    newProduct.ProductName = currProduct.ProductName;
                    newProduct.BasePrice = currProduct.Price;
                    //TODO: need help with query in ifs!!!
                    //db.Categories.Where(c => c.CategoryName == currProduct.Category).First()); 
                    if (true)
                    {
                        var newCategory = new ItShop.Model.Category();
                        newCategory.CategoryName = currProduct.Category;
                    }
                    if (true)
                    {
                        var newManufacturer = new ItShop.Model.Manufacturer();
                        newManufacturer.ManufacturerName = currProduct.Manufacturer;
                    }
                    newProduct.Category.CategoryName = currProduct.Category;
                    newProduct.Manufacturer.ManufacturerName = currProduct.Manufacturer;
                    db.Products.Add(newProduct);
                }
            }
            db.SaveChanges();
        }

        private static void ConvertStoresData(ItShopDbContext db, MongoDataReader reader)
        {
            var stores = reader.GetStores();

            foreach (var currStore in stores)
            {
                //to check query
                var sqlCurrentStore = db.Stores.Where(p => p.StoreName == currStore.StoreName);

                if (sqlCurrentStore == null)
                {
                    var newStore = new ItShop.Model.Store();
                    newStore.StoreName = currStore.StoreName;
                    //TODO: need help with query in ifs!!!
                    if (true)
                    {
                        var newAddress = new ItShop.Model.Address();
                        newAddress.AddressName = currStore.Address;
                    }
                    newStore.Address.AddressName = currStore.Address;
                    db.Stores.Add(newStore);
                }
            }
            db.SaveChanges();
        }
        private static void ConvertSalesData(ItShopDbContext db, MongoDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}