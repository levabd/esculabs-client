using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Repositories
{
    using Models;
    using Common.Logging;
    using Context;

    class PatientsRepository
    {
        private static volatile PatientsRepository  _instance;
        private static object                       _syncRoot = new object();

        private ILog                                _log;
        private PgSqlContext                        _context = null;

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
            _log = LogManager.GetLogger("Patients Repository");

            if (_context == null)
            {
               _context = new PgSqlContext();
            }
        }

        public Patient Find(int id)
        {
            return _context.Patients.Find(id);
        }

        public Patient Add(Patient patient)
        {
            Patient result = null;

            try
            {
                result = _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _log.Error(string.Format("Can't insert data to db. Reason: {0}", e.Message));
                result = null;
            }

            return result;
        }

        public List<Patient> All()
        {
            List<Patient> patients = null;

            try
            {
                patients = _context.Patients.OrderByDescending(p => p.Id).ToList();
            }
            catch (Exception e)
            {
                _log.Error(string.Format("Can't select data from db. Reason: {0}", e.Message));
                return null;
            }

            return patients;
        }
    }
}
