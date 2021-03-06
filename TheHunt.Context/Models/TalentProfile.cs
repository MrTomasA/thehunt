﻿using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class TalentProfile
    {
        public TalentProfile()
        {
            TalentSkillSet = new HashSet<TalentSkillSet>();
        }

        public int UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CurrentSalary { get; set; }
        public bool? IsAnnuallyMonthly { get; set; }
        public string Currency { get; set; }

        public UserAccount UserAccount { get; set; }
        public ICollection<TalentSkillSet> TalentSkillSet { get; set; }
    }
}
