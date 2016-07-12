namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        private SeedFactory SeedFactory => new SeedFactory();

        protected override void Seed(ApplicationDbContext context)
        {
            foreach (var seeder in this.SeedFactory.Seeders)
            {
                seeder.Seed(context);
            }
        }
    }
}
