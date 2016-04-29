namespace MvcTemplate.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using MvcTemplate.Common;

    public class SeedFactory
    {
        public SeedFactory()
        {
            this.LoadSeeders();
        }

        public ICollection<ISeeder> Seeders { get; set; } = new List<ISeeder>();

        private void LoadSeeders()
        {
            var assembly = Assembly.Load(Assemblies.Data);
            var types = assembly.GetExportedTypes();
            var seeders = types?.Where(
                x => x.GetInterfaces().Contains(typeof(ISeeder)) &&
                    !x.IsInterface &&
                    !x.IsAbstract);

            foreach (var seederType in seeders)
            {
                this.Seeders.Add((ISeeder)Activator.CreateInstance(seederType));
            }

            this.Seeders = this.Seeders.OrderBy(x => x.Priority).ToList();
        }
    }
}
