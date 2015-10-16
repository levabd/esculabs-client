namespace Client.Context
{
    using Models;
    using System.Data.Entity;

    public partial class BalderContext : DbContext
    {
        public BalderContext()
            : base("name=IgnisConnectionString")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.Iin)
                .IsFixedLength()
                .IsRequired();
        }
    }
}
