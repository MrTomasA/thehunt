using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class JobPost
    {
        public int Id { get; set; }
        public int PostedById { get; set; }
        public int JobTypeId { get; set; }
        public int CompanyId { get; set; }
        public bool IsCompanyNameHidden { get; set; }
        public DateTime CreatedDate { get; set; }
        public string JobDescription { get; set; }
        public int JobLocationId { get; set; }
        public bool IsActive { get; set; }

        public Company Company { get; set; }
        public JobLocation JobLocation { get; set; }
        public JobType JobType { get; set; }
        public UserAccount PostedBy { get; set; }
    }
}
