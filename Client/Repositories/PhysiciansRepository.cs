using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories
{
    using Models;
    using Common.Logging;
    using Context;
    using System.Security.Cryptography;

    class PhysiciansRepository
    {
        private static volatile PhysiciansRepository _instance;
        private static object _syncRoot = new object();

        private ILog _log;
        private PgSqlContext _context = null;

        public static PhysiciansRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new PhysiciansRepository();
                    }
                }

                return _instance;
            }
        }

        public PhysiciansRepository()
        {
            _log = LogManager.GetLogger("Physicians Repository");

            if (_context == null)
            {
                _context = new PgSqlContext();
            }
        }

        public Physician Find(int id)
        {
            return _context.Physicians.Find(id);
        }

        public Physician Authorize(string login, string password)
        {
            try
            {
                // byte array representation of that string
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

                // need MD5 to calculate the hash
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

                // string representation (similar to UNIX format)
                string encoded = BitConverter.ToString(hash)
                   // without dashes
                   .Replace("-", string.Empty)
                   // make lowercase
                   .ToLower();

                var lowerLogin = login.ToLower();
                var p = _context.Physicians.First(x => lowerLogin.Equals(x.Login.ToLower()) && encoded.Equals(x.Password));

                return p;
        }
            catch (Exception e)
            {
                _log.Error($"Failed authorization result. Username = {login}, Reason: {e.Message}");
            }

            return null;
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
                _log.Error($"Can't insert data to db. Reason: {e.Message}");
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
                _log.Error($"Can't select data from db. Reason: {e.Message}");
                return null;
            }

            return patients;
        }
    }
}
