namespace ItShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ItShopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //this.ContextKey = "ItShop.Data.ItShopDbContext";
        }

        protected override void Seed(ItShopDbContext context)
        {
        }
    }
}
