using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class TalentSkillSet
    {
        public int UserAccountId { get; set; }
        public int SkillSetId { get; set; }
        public int SkillLevel { get; set; }

        public SkillSet SkillSet { get; set; }
        public TalentProfile UserAccount { get; set; }
    }
}
