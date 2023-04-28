using DATALAYER.Models;
using DATALAYER.Repository;
using SERVICELAYER.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SERVICELAYER
{
    public class UserServices : IUserServices
    {
        IPasswordLockerRepo<UserStoredCredential> _userStoredCredLockerRepo;
        IPasswordLockerRepo<User> _userLockerRepo;

        public UserServices(IPasswordLockerRepo<UserStoredCredential> userStoredCredLockerRepo, IPasswordLockerRepo<User> userLockerRepo)
        {
            _userStoredCredLockerRepo = userStoredCredLockerRepo;
            _userLockerRepo = userLockerRepo;
        }

        public int DeleteCredentials(int credID)
        {
            return _userStoredCredLockerRepo.Delete(credID);
        }

        public int getSessionValue(string uname, string password)
        {
            var users =( from u in _userLockerRepo.GetAll()
                        where u.Username == uname && u.Password == password
                        select u.UserId).FirstOrDefault();
            return users;
        }

        public IEnumerable<UserStoredCredential> GetStoreCredentials(int id)
        {
            return from usercred in _userStoredCredLockerRepo.GetAll() where usercred.UserId==id select usercred;
        }

        public string GetStoredCredential(int id)
        {
            return (from usercred in _userStoredCredLockerRepo.GetAll() where usercred.Id == id select usercred.Website).First();
        }

        public int login(string uname, string password)
        {
            var users = from u in _userLockerRepo.GetAll()
                       where u.Username == uname && u.Password == password
                       select u;
            if (users.Count() > 0) 
                return 1;
            else
                return 0;
        }

        public int Register(User vaultUser)
        {
           return _userLockerRepo.Add(vaultUser);
        }

        public int StoreCredentials(UserStoredCredential credential)
        {
            return _userStoredCredLockerRepo.Add(credential);
        }


        public int UpdateCredentials(UserStoredCredential credential, int credID)
        {
            var cred = _userStoredCredLockerRepo.Get(credID);
            cred.Password = credential.Password;
            cred.Username = credential.Username;
            cred.Website = credential.Website;
            return _userStoredCredLockerRepo.Edit(cred);
        }
    }
}
