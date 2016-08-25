using AgeRanger.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AgeRanger.Repository
{
    public class AgeRangerContext : DbContext
    {
        public AgeRangerContext()
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<AgeRangerContext>(null);    
        }

        public DbSet<Person> People { get; set; }

        public DbSet<AgeGroup> AgeGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}