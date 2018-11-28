using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class Company
    {
        public Company()
        {
            JobPost = new HashSet<JobPost>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ProfileDescription { get; set; }
        public int BusinessStreamId { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string CompanyWebsiteUrl { get; set; }

        public BusinessStream BusinessStream { get; set; }
        public ICollection<JobPost> JobPost { get; set; }
    }
}
