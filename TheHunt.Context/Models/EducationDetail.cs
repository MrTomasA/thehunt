using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class EducationDetail
    {
        public int UserAccountId { get; set; }
        public string CertificateDegreeName { get; set; }
        public string Major { get; set; }
        public string InstitueUniversityName { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int? Percentage { get; set; }
        public decimal Gpa { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
