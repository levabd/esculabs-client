namespace EsculabsCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using EsculabsCommon;
    using System.Collections.Generic;
    using Context;

    internal sealed class Configuration : DbMigrationsConfiguration<PgSqlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PgSqlContext context)
        {
            if (!context.Patients.Any())
            {
                context.Patients.AddOrUpdate(
                  new Patient
                  {
                      FirstName = "Анатолий",
                      MiddleName = "Андреевич",
                      LastName = "Анатольев",
                      Birthdate = new DateTime(1983, 12, 23),
                      BloodGroup = 2,
                      Gender = PatientGender.Male,
                      Iin = "831223387948",
                      RhFactor = true
                  },
                  new Patient
                  {
                      FirstName = "Серик",
                      MiddleName = "Канатович",
                      LastName = "Шатаев",
                      Birthdate = new DateTime(1991, 10, 1),
                      BloodGroup = 1,
                      Gender = PatientGender.Male,
                      Iin = "911001387949",
                      RhFactor = true
                  },
                  new Patient
                  {
                      FirstName = "Фёдор",
                      MiddleName = "Сергеевич",
                      LastName = "Иванов",
                      Birthdate = new DateTime(1983, 12, 23),
                      BloodGroup = 1,
                      Gender = PatientGender.Male,
                      Iin = "831223387947",
                      RhFactor = false,
                  },
                  new Patient
                  {
                      FirstName = "Светлана",
                      MiddleName = "Ивановна",
                      LastName = "Дуденко",
                      Birthdate = new DateTime(1994, 1, 12),
                      BloodGroup = 4,
                      Gender = PatientGender.Female,
                      Iin = "940112387944",
                      RhFactor = false
                  },
                  new Patient
                  {
                      FirstName = "Иннеса",
                      MiddleName = "Игнатьевна",
                      LastName = "Попкова",
                      Birthdate = new DateTime(1976, 8, 27),
                      BloodGroup = 3,
                      Gender = PatientGender.Female,
                      Iin = "760827387945",
                      RhFactor = true
                  },
                  new Patient
                  {
                      FirstName = "Акмарал",
                      MiddleName = "Сейпиновна",
                      LastName = "Жанбурбаева",
                      Birthdate = new DateTime(1992, 1, 28),
                      BloodGroup = 2,
                      Gender = PatientGender.Female,
                      Iin = "920128387234",
                      RhFactor = true
                  },
                  new Patient
                  {
                      FirstName = "Максим",
                      MiddleName = "Игоревич",
                      LastName = "Погорелов",
                      Birthdate = new DateTime(1993, 2, 7),
                      BloodGroup = 2,
                      Gender = PatientGender.Male,
                      Iin = "930207387345",
                      RhFactor = true
                  },
                  new Patient
                  {
                      FirstName = "Антон",
                      MiddleName = "Сергеевич",
                      LastName = "Овчаров",
                      Birthdate = new DateTime(1962, 6, 23),
                      BloodGroup = 1,
                      Gender = PatientGender.Male,
                      Iin = "62623387657",
                      RhFactor = true
                  }
              );
            }

            if (!context.Physicians.Any())
            {
                context.Physicians.AddOrUpdate(
                    new Physician
                    {
                        FirstName = "Алексей",
                        MiddleName = "Григорьевич",
                        LastName = "Попов",
                        Login = "antrille",
                        Password = "40f96bc52f69c669626b95c7994e6eac",
                        Position = "Разработчик системы",
                        Roles = new List<Role>() { new Role { Name = "developer", Description = "Разработчик Esculabs"} }
                    }
                );

                context.Roles.AddOrUpdate(
                    new Role
                    {
                        Description = "Поддержка",
                        Name = "support"
                    },
                    new Role
                    {
                        Description = "Врач",
                        Name = "physician"
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
