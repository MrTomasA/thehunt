using System;

namespace TheHunt.DomainModel.Models
{
    public class UserLog
    {
        public int UserAccountId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastJobApplyDate { get; set; }
    }
}