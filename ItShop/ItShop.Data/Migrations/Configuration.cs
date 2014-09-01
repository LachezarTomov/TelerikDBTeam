namespace ItShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ItShop.Data.ItShopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "ItShop.Data.ItShopDbContext";
        }

        protected override void Seed(ItShop.Data.ItShopDbContext context)
        {
        }
    }
}
