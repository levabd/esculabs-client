namespace FibrosisModule.Context
{
    using System.IO;
    using Windows.Storage;
    using Models;
    using Microsoft.Data.Entity;

    public class FibrosisContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Esculabs.db");
        }

        public DbSet<FibrosisExamine> Examines { get; set; }
        public DbSet<FibrosisMeasure> Measures { get; set; }
        public DbSet<FibrosisPatientMetric> PatientMetrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Patient>()
            //    .Property(e => e.Iin)
            //    .IsRequired();
        }
    }
}
