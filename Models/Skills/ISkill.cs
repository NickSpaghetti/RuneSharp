using RuneSharp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Models.Skills
{
    public interface ISkill
    {
        SkillName Name { get; set; }
        int Level { get; set; }
        long Experence { get; set; }
        long ExperenceToNextLevel { get; set; }
        long Rank { get; set; }
        bool IsMembersSkill { get; set; }
        SkillCategory SkillCategory { get; set; }
    }
}
