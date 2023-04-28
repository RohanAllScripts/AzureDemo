using System;
using System.Collections.Generic;

#nullable disable

namespace DATALAYER.Models
{
    public partial class User
    {
        public User()
        {
            UserStoredCredentials = new HashSet<UserStoredCredential>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserStoredCredential> UserStoredCredentials { get; set; }
    }
}
