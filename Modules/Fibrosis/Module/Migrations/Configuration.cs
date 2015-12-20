namespace Fibrosis.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Context;

    internal sealed class Configuration : DbMigrationsConfiguration<PgSqlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PgSqlContext context)
        {
            if (!context.Examines.Any())
            {
                context.Examines.AddOrUpdate(
                  new Examine
                  {
                      CreatedAt = new DateTime(),
                      Duration = 224,
                      ExpertStatus = ExpertStatus.Pending,
                      Iqr = 5.2,
                      Med = 15.0,
                      PatientId = 1,
                      PhysicianId = 1,
                      SensorType = SensorType.Xl,
                      Valid = true
                  },
                  new Examine
                  {
                      CreatedAt = new DateTime(),
                      Duration = 229,
                      ExpertStatus = ExpertStatus.Pending,
                      Iqr = 2.5,
                      Med = 12.0,
                      PatientId = 2,
                      PhysicianId = 1,
                      SensorType = SensorType.Xl,
                      Valid = false
                  }
                );
            }

            if (!context.PatientMetrics.Any())
            {
                context.PatientMetrics.AddOrUpdate(
                    new PatientMetric
                    {
                        PatientId = 1,
                        Scd = 2.4,
                        Tp = 1.3
                    },
                    new PatientMetric
                    {
                        PatientId = 2,
                        Scd = 2.2,
                        Tp = 1.5
                    }
                );
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
