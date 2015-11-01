using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibrosis.Repositories
{
    using Models;
    using System.Data.Entity;
    using Context;

    class ExaminesRepository
    {
        private static volatile ExaminesRepository _instance;
        private static object                       _syncRoot = new object();

        private PgSqlContext                     _context = null;

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
            if (_context == null)
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlContext, Migrations.Configuration>("PgSqlConnectionString"));

                _context = new PgSqlContext();
            }
        }

        public FibrosisExamine Find(int id)
        {
            return _context.Examines.Find(id);
        }
    }
}
