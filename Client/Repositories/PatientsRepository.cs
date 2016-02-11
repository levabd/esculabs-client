using Microsoft.Data.Entity;

namespace Client.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Context;

    public class PatientsRepository
    {
        private static PatientsRepository _instance;
        private static readonly object SyncRoot = new object();

        private readonly EsculabsContext _db;

        public static PatientsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        _instance = new PatientsRepository();
                    }
                }

                return _instance;
            }
        }

        public PatientsRepository()
        {
            _db = new EsculabsContext();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _db.Patients.Include(p => p.Examines).ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
