using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class UserLog
    {
        public int UserAccountId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastJobApplyDate { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
