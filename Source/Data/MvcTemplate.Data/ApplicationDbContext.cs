namespace MvcTemplate.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // For faster test data insertions disabled the following properties
            // this.Configuration.AutoDetectChangesEnabled = false;
            // this.Configuration.ValidateOnSaveEnabled = false;
        }

        public IDbSet<Workplace> Workplaces { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        /// <summary>
        /// Approach via @julielerman: http://bit.ly/123661P
        /// </summary>
        private void ApplyAuditInfoRules()
        {
            var changeTrackerEntries =
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditInfo &&
                            ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in changeTrackerEntries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now; // TODO: Introduce DateTimeProvider and replace all DateTime.Now calls
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
