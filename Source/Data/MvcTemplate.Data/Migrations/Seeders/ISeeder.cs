namespace MvcTemplate.Data.Migrations.Seeders
{
    public interface ISeeder
    {
        int Priority { get; }

        void Seed(ApplicationDbContext context);
    }
}
