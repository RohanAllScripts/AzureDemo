using System;
using System.Collections.Generic;

#nullable disable

namespace DATALAYER.Models
{
    public partial class UserStoredCredential
    {
        public int Id { get; set; }
        public string Website { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
