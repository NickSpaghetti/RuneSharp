using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Skills
{
    public abstract class Skill : ISkill
    {
        public SkillName Name { get; set; }
        public int Level { get; set; }
        public long Experence { get; set; }
        public long ExperenceToNextLevel { get; set; }
        public long Rank { get; set; }
        public bool IsMembersSkill { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}
