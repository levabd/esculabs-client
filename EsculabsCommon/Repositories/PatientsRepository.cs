using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsculabsCommon.Repositories
{
    using Models;
    using Context;

    public class PatientsRepository
    {
        private static volatile PatientsRepository  _instance;
        private static object                       _syncRoot = new object();

        //private ILog                                _log;

        public static PatientsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new PatientsRepository();
                    }
                }

                return _instance;
            }
        }

        public PatientsRepository()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlContext, Migrations.Configuration>("PgSqlConnectionString"));

            //_log = LogManager.GetLogger("Patients Repository");
        }

        public Patient Find(int id)
        {
            using (var context = new PgSqlContext())
            {
                return context.Patients.Find(id);
            }
        }

        public Patient Add(Patient patient)
        {
            Patient result;

            try
            {
                using (var context = new PgSqlContext())
                {
                    result = context.Patients.Add(patient);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //_log.Error($"Can't insert data to db. Reason: {e.Message}");
                result = null;
            }

            return result;
        }

        public async Task<List<Patient>> AllAsync()
        {
            try
            {
                using (var db = new PgSqlContext())
                {
                    return await db.Patients.OrderByDescending(p => p.Id).ToListAsync();
                }
            }

            catch (Exception e)
            {
                //_log.Error($"Can't select data from db. Reason: {e.Message}");
                return null;
            }
        }
    }
}
