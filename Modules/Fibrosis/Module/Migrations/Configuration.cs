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
            if (context.Examines.Any())
            {
                return;
            }

            context.Examines.AddOrUpdate(
              new Examine
              {
                  CreatedAt = new DateTime(),
                  Duration = 2300,
                  ExpertStatus = ExpertStatus.Pending,
                  Iqr = 2.0,
                  Med = 13.0,
                  PatientId = 1,
                  PhysicianId = 1,
                  SensorType = SensorType.Xl,
                  Valid = true                  
              },
              new Examine
              {
                  CreatedAt = new DateTime(),
                  Duration = 2100,
                  ExpertStatus = ExpertStatus.Pending,
                  Iqr = 3.0,
                  Med = 14.0,
                  PatientId = 2,
                  PhysicianId = 1,
                  SensorType = SensorType.Small,
                  Valid = false
              }
            );

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
