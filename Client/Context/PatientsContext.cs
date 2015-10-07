namespace Client
{
    using Models;
    using System.Data.Entity;

    public partial class PatientsContext : DbContext
    {
        public PatientsContext()
            : base("name=IgnisConnectionString")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.Iin)
                .IsFixedLength()
                .IsRequired();
        }
    }
}
