namespace MongoDB.Data
{
    using System;
    using System.Linq;

    using MongoDB.Model;
    internal class MongoDataSeeder
    {

        public static void Seeder()
        {

            var inserter = new MongoDataInserter();

            inserter.AddManufacturer(new Manufacturer("Dell Inc.", "Worldwide leader in computer development", "Michael Dell"));
            inserter.AddManufacturer(new Manufacturer("Hewlett-Packard", "Worldwide leader in hardware, software and services", "Meg Whitman"));
            inserter.AddManufacturer(new Manufacturer("IBM Inc.", "Worldwide leader in computer development", "Michael Dell"));
            inserter.AddManufacturer(new Manufacturer("Toshiba Corporation", "Worldwide leader in engineering and electronics conglomerate", "Hisao Tanaka"));
            inserter.AddManufacturer(new Manufacturer("ASUSTeK Computer Inc.", "Computer hardware and electronics company", "Jonney Shih"));
            inserter.AddManufacturer(new Manufacturer("Lenovo Group Ltd.", "Leader in computer technology", "Yang Yuanqing"));
            inserter.AddManufacturer(new Manufacturer("Micro-Star International Co., Ltd (MSI)", "Large information technology manufacturer", "Xu Xiang"));
            inserter.AddManufacturer(new Manufacturer("Apple Inc.", "Worldwide leader in consumer electronics, computer software, online services, and personal computers", "Tim Cook"));
            inserter.AddManufacturer(new Manufacturer("Acer Inc.", "Leader in hardware and electronics corporation", "Stan Shih"));
            inserter.AddManufacturer(new Manufacturer("Sony Corporation", "Worldwide leader in electronics, game, entertainment", "Kazuo Hirai"));


        }
    }
}
