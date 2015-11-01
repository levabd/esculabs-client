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

        public DbSet<FibrosisExamine> Examines { get; set; }
    }
}
