namespace Client.Repositories
{
    using System;
    using System.Linq;
    using Models;
    using Context;
    using Helpers;

    public class UsersRepository
    {
        private static volatile UsersRepository _instance;
        private static object _syncRoot = new object();

        public static UsersRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new UsersRepository();
                    }
                }

                return _instance;
            }
        }

        public User Find(int id)
        {
            using (var db = new EsculabsContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public User TryLogin(string login, string password)
        {
            try
            {
               var lowerLogin = login.ToLower();

                using (var db = new EsculabsContext())
                {
                    var encryptedPass = Encryption.Encrypt(password);

                    return db.Users.FirstOrDefault(x => lowerLogin.Equals(x.Login.ToLower()) 
                            && encryptedPass == x.Password);
                }
            }
            catch (Exception e)
            {
                //_log.Error($"Failed authorization result. Username = {login}, Reason: {e.Message}");
            }

            return null;
        }


    }
}
