namespace Client.Context
{
    using System.IO;
    using Windows.Storage;
    using Models;
    using Microsoft.Data.Entity;

    public class EsculabsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Esculabs.db");
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Examine> Examines { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<PatientMetric> PatientMetrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Examines)
                .WithOne(b => b.Patient);

            modelBuilder.Entity<Examine>()
                .HasMany(p => p.Measures)
                .WithOne(b => b.Examine);

            modelBuilder.Entity<Examine>()
                .HasOne(p => p.PatientMetric);

            modelBuilder.Entity<Examine>()
                .HasOne(p => p.User);

            //    .Property(e => e.Iin)
            //    .IsRequired();
        }
    }
}
