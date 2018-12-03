using System;

namespace TheHunt.DomainModel.Models
{
    public class UserAccount
    {
        public int? Id { get; set; }
        public int UserTypeId { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber { get; set; }
        public bool? EmailNotificationActive { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}