using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class JobPostSkillSet
    {
        public int SkillSetId { get; set; }
        public int JobPostId { get; set; }
        public int? SkillLevel { get; set; }
    }
}
