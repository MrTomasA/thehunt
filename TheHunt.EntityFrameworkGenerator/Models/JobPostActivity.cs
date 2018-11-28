using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class JobPostActivity
    {
        public int UserAccountId { get; set; }
        public int JostPostId { get; set; }
        public DateTime? ApplyDate { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
