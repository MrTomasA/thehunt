using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class ExperienceDetails
    {
        public int UserAccountId { get; set; }
        public bool IsCurrentJob { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string JobLocationCity { get; set; }
        public string JobLocationState { get; set; }
        public string JobLocationCountry { get; set; }
        public string Description { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
