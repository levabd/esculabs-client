using FibrosisModule.Models;
using Microsoft.Data.Entity;

namespace Client.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Context;

    public class ExaminesRepository
    {
        private static ExaminesRepository _instance;
        private static readonly object SyncRoot = new object();

        private readonly EsculabsContext _db;

        public static ExaminesRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        _instance = new ExaminesRepository();
                    }
                }

                return _instance;
            }
        }

        public ExaminesRepository()
        {
            _db = new EsculabsContext();
        }
    }
}
