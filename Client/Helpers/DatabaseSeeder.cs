using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Context;
using Client.Models;

namespace Client.Helpers
{
    public static class DatabaseSeeder
    {
        public static bool SeedPatients(EsculabsContext context)
        {
            if (context.Patients.Any())
            {
                return false;
            }

            context.Patients.AddRange(
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

            return true;
        }

        public static bool SeedUsers(EsculabsContext context)
        {
            if (context.Users.Any())
            {
                return false;
            }

            context.Users.Add(
                new User
                {
                    FirstName = "Алексей",
                    MiddleName = "Григорьевич",
                    LastName = "Попов",
                    Login = "antrille",
                    Password = "VlRsDIOawL69/A3mKXUzrPHAbPV18iE/xzZoL0XXM8YPOTne55uL4zwS4wUC6zKip98FqadSwgHQluQPW2XTiA==",
                    Position = "Разработчик системы",
                    Role = UserRole.Developer
                }
            );

            return true;
        }

        public static bool SeedExamines(EsculabsContext context)
        {
            if (context.Examines.Any())
            {
                return false;
            }

            context.Examines.Add(
                new Examine
                {
                    PatientIin = "62623387657",
                    Duration = 233,
                    CreatedAt = new DateTime(),
                    ExpertStatus = ExpertStatus.Confirmed,
                    FibxSource = "nope",
                    Iqr = 10,
                    Med = 5.2,
                    SensorType = SensorType.Xl,
                    Valid = true
                }
            );

            return true;
        }
    }
}
