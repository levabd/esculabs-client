using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repo
{
    using MongoRepository;
    using Common.Logging;

    class PatientsRepo : IRepository
    {
        private static ILog log;

        public PatientsRepo()
        {
            log = LogManager.GetLogger("PatientsRepo");
        }

        public static List<TablePatient> GridList()
        {
            List<Patient> patients = null;
            List<Examine> examinesPool = null;

            try {
                MongoRepository<Examine> examines = new MongoRepository<Examine>();

                patients = new PgContext().Patients.OrderByDescending(p => p.Id).ToList();
                var patientsIds = patients.Select(p => p.Id).ToList();
                examinesPool = examines.Where(ex => patientsIds.Contains(ex.PatientId))
                    .OrderByDescending(ex => ex.CreatedAt)
                    .ToList();
            }
            catch (Exception e)
            {
                log.Error(string.Format("Can't select data from db. Reason: {0}", e.Message));
                return null;
            }

            List<TablePatient> tablePatients = new List<TablePatient>();
            foreach (Patient patient in patients)
            {
                var patientExamines = examinesPool.Where(ex => ex.PatientId == patient.Id).ToList();

                if (patientExamines.Any())
                {
                    var examine = patientExamines.First();
                    var tp = new TablePatient(patient, examine);

                    tablePatients.Add(tp);
                }
            }

            return tablePatients;
        }
    }
}
