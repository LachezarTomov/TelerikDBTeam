namespace MongoDB.Data
{
    using System;
    using System.Linq;

    using MongoDB.Model;
    internal class MongoDataSeeder
    {

        public static void ManufacturerSeeder()
        {

            var inserter = new MongoDataInserter();

            inserter.AddManufacturer(new Manufacturer("Dell", "Worldwide leader in computer development", "Michael Dell"));
            inserter.AddManufacturer(new Manufacturer("Hewlett-Packard", "Worldwide leader in hardware, software and services", "Meg Whitman"));
            inserter.AddManufacturer(new Manufacturer("IBM", "Worldwide leader in computer development", "Ginni Rometty"));
            inserter.AddManufacturer(new Manufacturer("Toshiba", "Worldwide leader in engineering and electronics conglomerate", "Hisao Tanaka"));
            inserter.AddManufacturer(new Manufacturer("ASUS", "Computer hardware and electronics company", "Jonney Shih"));
            inserter.AddManufacturer(new Manufacturer("Lenovo", "Leader in computer technology", "Yang Yuanqing"));
            inserter.AddManufacturer(new Manufacturer("MSI", "Large information technology manufacturer", "Xu Xiang"));
            inserter.AddManufacturer(new Manufacturer("Apple", "Worldwide leader in consumer electronics, computer software, online services, and personal computers", "Tim Cook"));
            inserter.AddManufacturer(new Manufacturer("Acer", "Leader in hardware and electronics corporation", "Stan Shih"));
            inserter.AddManufacturer(new Manufacturer("Sony", "Worldwide leader in electronics, game, entertainment", "Kazuo Hirai"));
            inserter.AddManufacturer(new Manufacturer("Samsung", "Worldwide business conglomerate", "Lee Kun-hee"));
        }

        public static void ProductSeeder()
        {
            var inserter = new MongoDataInserter();

            inserter.AddProduct(new Product("Dell Inspiron 3537", "laptop", "Dell", 899.00m));
            inserter.AddProduct(new Product("Toshiba Satellite L50-B-16C", "laptop", "Toshiba", 1369.00m));
            inserter.AddProduct(new Product("ASUS G750JZ-T4039D", "laptop", "ASUS", 2779.00m));
            inserter.AddProduct(new Product("Acer Аspire ES1-511 L50-B-16C", "laptop", "Acer", 549.00m));
            inserter.AddProduct(new Product("Apple MacBook Air", "laptop", "Apple", 1825.00m));

            inserter.AddProduct(new Product("Samsung Galaxy Tab 4 10.1 (SM-T535)", "tablet", "Samsung", 689.00m));
            inserter.AddProduct(new Product("ASUS MeMO Pad 7 (ME176C) 8GB", "tablet", "ASUS", 259.00m));
            inserter.AddProduct(new Product("Apple iPad Mini Retina Wi-Fi 16GB", "tablet", "Apple", 699.00m));
            inserter.AddProduct(new Product("Dell Venue 7", "tablet", "Dell", 269.00m));
            inserter.AddProduct(new Product("HP Slate 10 HD 3603eu", "tablet", "Samsung", 399.00m));

            inserter.AddProduct(new Product("Acer Predator G3-605", "pc", "Acer", 1599.00m));
            inserter.AddProduct(new Product("Mac Pro", "pc", "Apple", 5999.00m));
            inserter.AddProduct(new Product("ASUS Essentio CG8250", "pc", "ASUS", 1099.00m));
            inserter.AddProduct(new Product("Dell Alienware X51", "pc", "Dell", 1699.00m));
            inserter.AddProduct(new Product("HP ProDesk 600 G1", "pc", "Hewlett-Packard", 936.00m));
        }

        public static void StoreSeeder()
        {
            var inserter = new MongoDataInserter();

            inserter.AddStore(new Store("Laptop.bg", "135 Tsarigradsko Shausse blvd.", "Sofia"));
            inserter.AddStore(new Store("Most Computers", "37 Shipchenski Prokhod Blvd.", "Sofia"));
            inserter.AddStore(new Store("PIC Computers", "91 Bogomil Str.", "Plovdiv"));
            inserter.AddStore(new Store("PIC Computers", "67 Demokratsia.", "Burgas"));
            inserter.AddStore(new Store("PCStore.bg", "48 Evlogi Georgiev blvd.", "Sofia"));
            inserter.AddStore(new Store("Most Computers - Easy Office", "1 Dunav str.", "Burgas"));
            inserter.AddStore(new Store("Most Computers - Digit", "32 Hadji Stamat str.", "Varna"));
        }
    }
}
