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

    class ExaminesRepository
    {
        private static volatile ExaminesRepository _instance;
        private static object                       _syncRoot = new object();

        public static ExaminesRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new ExaminesRepository();
                    }
                }

                return _instance;
            }
        }

        public ExaminesRepository()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlContext, Migrations.Configuration>("PgSqlConnectionString"));
        }

        public Examine Find(int id)
        {
            using (var db = new PgSqlContext())
            {
                return db.Examines.Find(id);
            }
        }

        public async Task<List<Examine>> AllAsync()
        {
            try
            {
                using (var db = new PgSqlContext())
                {
                    return await db.Examines.OrderByDescending(p => p.Id).ToListAsync();
                }
            }

            catch (Exception e)
            {
                return null;
            }
        }
    }
}
