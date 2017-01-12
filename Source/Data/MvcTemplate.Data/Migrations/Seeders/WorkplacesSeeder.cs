namespace MvcTemplate.Data.Migrations.Seeders
{
    using MvcTemplate.Data.Models;

    public class WorkplacesSeeder : ISeeder
    {
        public int Priority
        {
            get
            {
                return 10;
            }
        }

        public void Seed(ApplicationDbContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                var workplace = new Workplace()
                {
                    Name = "Name " + i,
                    MyProperty1 = "Propaaah",
                    MyProperty2 = "Propaaah",
                    MyProperty3 = "Propaaah",
                    MyProperty4 = "Propaaah",
                    MyProperty5 = "Propaaah"
                };

                context.Workplaces.Add(workplace);
            }

            context.SaveChanges();
        }
    }
}
