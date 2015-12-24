using System.Collections.Generic;

namespace Client.Repositories
{
    using System;
    using System.Linq;
    using Models;
    using Context;
    using Helpers;

    public class UsersRepository
    {
        private static UsersRepository _instance;
        private static readonly object SyncRoot = new object();

        private readonly EsculabsContext _db;

        public static UsersRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        _instance = new UsersRepository();
                    }
                }

                return _instance;
            }
        }

        public UsersRepository()
        {
            _db = new EsculabsContext();
        }

        public User Find(int id)
        {
            return _db.Users.FirstOrDefault(x => x.Id == id);
        }

        public User TryLogin(string login, string password)
        {
            try
            {
                var lowerLogin = login.ToLower();
                var encryptedPass = Encryption.HashString(password);

                return _db.Users.FirstOrDefault(x => lowerLogin.Equals(x.Login.ToLower()) 
                        && encryptedPass == x.Password);
            }
            catch (Exception e)
            {
                //_log.Error($"Failed authorization result. Username = {login}, Reason: {e.Message}");
            }

            return null;
        }


    }
}
