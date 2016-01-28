using FibrosisModule.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Patient>()
            //    .Property(e => e.Iin)
            //    .IsRequired();
        }
    }
}
