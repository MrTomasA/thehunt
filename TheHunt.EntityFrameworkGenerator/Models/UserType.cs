using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class UserType
    {
        public UserType()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string UserTypeName { get; set; }

        public ICollection<UserAccount> UserAccount { get; set; }
    }
}
