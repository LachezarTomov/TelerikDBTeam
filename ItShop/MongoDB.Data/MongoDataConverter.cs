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
                //ConvertManufacturersData(db, reader);
                //ConvertStoresData(db, reader);
                ConvertProductsData(db,reader);               
                //ConvertSalesData(db,reader);
            }
        }

        private static void ConvertManufacturersData(ItShopDbContext db, MongoDataReader reader)
        {
            var manufacturers = reader.GetManufacturers();

            foreach (var currManufacturer in manufacturers)
            {
                //to check query
                var sqlCurrentManufacturer = db.Manufacturers.Where(m => m.ManufacturerName == currManufacturer.ManufacturerName).FirstOrDefault();

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
                var sqlCurrentProduct = db.Products.Where(p => p.ProductName == currProduct.ProductName).FirstOrDefault();

                if (sqlCurrentProduct == null)
                {
                    var newProduct = new ItShop.Model.Product();
                    newProduct.ProductName = currProduct.ProductName;
                    newProduct.BasePrice = currProduct.Price;
                    var categoryID = db.Categories.Where(c => c.CategoryName == currProduct.Category).Select(x => x.CategoryID).FirstOrDefault();
                    if (categoryID == 0)
                    {
                        var newCategory = new ItShop.Model.Category();
                        newCategory.CategoryName = currProduct.Category;
                        newProduct.Category = newCategory;
                    }
                    else
                    {
                        newProduct.Category.CategoryID = categoryID;
                    }
                    var manufacturerId = db.Manufacturers.Where(c => c.ManufacturerName == currProduct.Manufacturer).Select(x => x.ManufacturerID).FirstOrDefault();

                    if (manufacturerId == 0)
                    {
                        var newManufacturer = new ItShop.Model.Manufacturer();
                        newManufacturer.ManufacturerName = currProduct.Manufacturer;
                        newProduct.Manufacturer = newManufacturer;
                    }
                    else
                    {
                        newProduct.ManufacturerId = manufacturerId;
                    }

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
                var sqlCurrentStore = db.Stores.Where(p => p.StoreName == currStore.StoreName).FirstOrDefault();
                if (sqlCurrentStore == null)
                {
                    var newStore = new ItShop.Model.Store();
                    newStore.StoreName = currStore.StoreName;
                    var addressId = db.Addresses.Where(a => a.AddressName == currStore.Address).Select(x => x.AddressId).FirstOrDefault();
                    if (addressId == 0)
                    {
                        var newAddress = new ItShop.Model.Address();
                        newAddress.AddressName = currStore.Address;
                        newStore.Address = newAddress;

                        var townId = db.Towns.Where(a => a.TownName == currStore.Town).Select(x => x.TownId).FirstOrDefault();
                        //System.Console.WriteLine(townId.);
                        if (townId == 0)
                        {
                            var newTown = new ItShop.Model.Town();
                            newTown.TownName = currStore.Town;
                            newStore.Address.Town = newTown;
                        }
                        else
                        {
                            newStore.Address.TownId = townId;
                        }
                    }
                    else
                    {
                        newStore.AddressId = addressId;
                    }

                    db.Stores.Add(newStore);
                }
                db.SaveChanges();
            }
            
        }
        private static void ConvertSalesData(ItShopDbContext db, MongoDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}