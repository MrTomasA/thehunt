using System;

namespace TheHunt.DomainModel.Models
{
    public class Company
    {
        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public string ProfileDescription { get; set; }
        public int BusinessStreamId { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string CompanyWebsiteUrl { get; set; }
    }
}