using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            EducationDetail = new HashSet<EducationDetail>();
            ExperienceDetails = new HashSet<ExperienceDetails>();
            JobPost = new HashSet<JobPost>();
            JobPostActivity = new HashSet<JobPostActivity>();
        }

        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber { get; set; }
        public bool? EmailNotificationActive { get; set; }
        public DateTime RegistrationDate { get; set; }

        public UserType UserType { get; set; }
        public TalentProfile TalentProfile { get; set; }
        public UserLog UserLog { get; set; }
        public ICollection<EducationDetail> EducationDetail { get; set; }
        public ICollection<ExperienceDetails> ExperienceDetails { get; set; }
        public ICollection<JobPost> JobPost { get; set; }
        public ICollection<JobPostActivity> JobPostActivity { get; set; }
    }
}
