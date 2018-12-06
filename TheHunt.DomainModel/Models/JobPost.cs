using System;

namespace TheHunt.DomainModel.Models
{
    public class JobPost
    {
        public int? Id { get; set; }
        public int PostedById { get; set; }
        public int JobTypeId { get; set; }
        public int CompanyId { get; set; }
        public bool IsCompanyNameHidden { get; set; }
        public DateTime CreatedDate { get; set; }
        public string JobDescription { get; set; }
        public int JobLocationId { get; set; }
        public bool IsActive { get; set; }
    }
}