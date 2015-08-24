namespace Client
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientContext : DbContext
    {
        public PatientContext()
            : base("name=PatientContext")
        {
        }

        public virtual DbSet<Patient> patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.iin)
                .IsFixedLength();
        }
    }
}
