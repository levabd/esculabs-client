namespace EsculabsCommon.Context
{
    using Models;
    using System.Data.Entity;

    public class PgSqlContext : DbContext
    {
        public PgSqlContext()
            : base("name=PgSqlConnectionString")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.Iin)
                .IsFixedLength()
                .IsRequired();

            modelBuilder.Entity<Physician>()
                            .HasMany(r => r.Roles)
                            .WithMany(p => p.Physicians)
                            .Map(mc =>
                            {
                                mc.ToTable("physicians_roles", "public");
                                mc.MapLeftKey("physician_id");
                                mc.MapRightKey("role_id");
                            });
        }
    }
}
