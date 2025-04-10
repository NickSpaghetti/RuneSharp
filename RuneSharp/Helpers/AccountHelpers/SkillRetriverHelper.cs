using RuneSharp.Enums;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Helpers.AccountHelpers
{
    public static class SkillRetriverHelper
    {
        public static OsRsSkill GetOsRsSkill(List<OsRsSkill> skills, SkillName skillName)
        {
            return skills.First(s => s.Name == skillName);
        }

        public static List<OsRsSkill> GetOsRsSkills(List<OsRsSkill> skills, SkillCategory skillCategory)
        {
            return skills.Where(s => s.SkillCategory == skillCategory).ToList();
        }

        public static List<OsRsSkill> GetOsRsSkills(List<OsRsSkill> skills, bool isMembersSkill)
        {
            return skills.Where(s => s.IsMembersSkill == isMembersSkill).ToList();
        }

        public static Rs3Skill GetOsRsSkill(List<Rs3Skill> skills, SkillName skillName)
        {
            return skills.First(s => s.Name == skillName);
        }

        public static List<Rs3Skill> Rs3Skill(List<Rs3Skill> skills, SkillCategory skillCategory)
        {
            return skills.Where(s => s.SkillCategory == skillCategory).ToList();
        }

        public static List<Rs3Skill> Rs3Skill(List<Rs3Skill> skills, bool isMembersSkill)
        {
            return skills.Where(s => s.IsMembersSkill == isMembersSkill).ToList();
        }
    }
}
