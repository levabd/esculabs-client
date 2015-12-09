using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibrosis.Repositories
{
    using Models;
    using System.Data.Entity;
    using Context;

    class FibrosisRepository
    {
        private static volatile FibrosisRepository  _instance;
        private static object                       _syncRoot = new object();

        public static FibrosisRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FibrosisRepository();
                    }
                }

                return _instance;
            }
        }

        public FibrosisRepository()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlContext, Migrations.Configuration>("PgSqlConnectionString"));
        }

        public Examine FindExamine(int id)
        {
            using (var db = new PgSqlContext())
            {
                return db.Examines.Find(id);
            }
        }

        public int AddExamine(Examine e)
        {
            using (var db = new PgSqlContext())
            {
                db.Examines.Add(e);
                return db.SaveChanges();
            }
        }

        public async Task<List<Examine>> AllExaminesAsync(int patientId)
        {
            try
            {
                using (var db = new PgSqlContext())
                {
                    return await db.Examines
                        .OrderByDescending(p => p.Id)
                        .Where(x => x.PatientId == patientId)
                        .Include(e => e.Measures)
                        .ToListAsync();
                }
            }

            catch (Exception)
            {
                return null;
            }
        }

        public Examine GetLastExamine(int patientId)
        {
            using (var db = new PgSqlContext())
            {
                return db.Examines.OrderByDescending(x => x.CreatedAt).FirstOrDefault(p => p.PatientId == patientId);
            }
        }

        public PatientMetric GetPatientMetric(int patientId)
        {
            using (var db = new PgSqlContext())
            {
                return db.PatientMetrics.FirstOrDefault(p => p.PatientId == patientId);
            }
        }
    }
}
