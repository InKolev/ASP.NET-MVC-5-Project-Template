namespace MvcTemplate.Data.Migrations.Seeders
{
    public interface ISeeder
    {
        int Priority { get; set; }

        void Seed(ApplicationDbContext context);
    }
}
