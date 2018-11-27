﻿using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class SkillSet
    {
        public SkillSet()
        {
            TalentSkillSet = new HashSet<TalentSkillSet>();
        }

        public int Id { get; set; }
        public string SkillSetName { get; set; }

        public ICollection<TalentSkillSet> TalentSkillSet { get; set; }
    }
}
