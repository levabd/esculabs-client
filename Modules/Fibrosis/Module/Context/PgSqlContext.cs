namespace Fibrosis.Context
{
    using Models;
    using System.Data.Entity;

    public partial class PgSqlContext : DbContext
    {
        public PgSqlContext()
            : base("name=PgSqlConnectionString")
        {
        }

        public DbSet<Examine> Examines { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<PatientMetric> PatientMetrics { get; set; }

    }
}
