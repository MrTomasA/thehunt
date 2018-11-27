using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class JobPostSkillSet
    {
        public int SkillSetId { get; set; }
        public int JobPostId { get; set; }
        public int? SkillLevel { get; set; }
    }
}
