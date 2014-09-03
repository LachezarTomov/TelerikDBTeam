
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItShop.Model;
using ItShop.Data.Migrations;

namespace ItShop.Data
{
    public class ItShopDbContext : DbContext
    {
        public ItShopDbContext()
            : base("name=ItShop")
        {
            Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<ItShopDbContext, Configuration>());

        }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Store> Stores { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<SaleDetail> SaleDetails { get; set; }

        public IDbSet<StoresExpenses> StoresExpenses { get; set; }

    }
}
