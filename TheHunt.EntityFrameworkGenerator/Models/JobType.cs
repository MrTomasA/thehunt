using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class JobType
    {
        public JobType()
        {
            JobPost = new HashSet<JobPost>();
        }

        public int Id { get; set; }
        public string JobType1 { get; set; }

        public ICollection<JobPost> JobPost { get; set; }
    }
}
