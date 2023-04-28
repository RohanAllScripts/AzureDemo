using DATALAYER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICELAYER.Interface
{
    public interface IUserServices
    {
        int login(string uname, string password);
        int Register(User vaultUser);
        int StoreCredentials (UserStoredCredential credential);
        IEnumerable<UserStoredCredential> GetStoreCredentials(int id);
        int UpdateCredentials (UserStoredCredential credential,int credID);
        int DeleteCredentials (int credID);
        int getSessionValue(string uname, string password);
        string GetStoredCredential(int id);
    }
}
