using RuneSharp.Enums;
using RuneSharp.Models.AccountTypes;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Skills
{
    public abstract class SkillsHiscoresQuerying<SkillVersion> : ISkillsHiscoresQuerying<SkillVersion> where SkillVersion : ISkill
    {
        public abstract SkillVersion GetSkill(SkillName skillName, AccountType accountType, string userName);

        public bool IsHigherRank(SkillVersion skillVersionOne, SkillVersion skillVersionTwo)
        {
            var isHigher = false;
            if(skillVersionOne.Rank < skillVersionTwo.Rank)
            {
                return isHigher;
            }
            else
            {
                isHigher = true;
            }

            return isHigher;
        }

        public virtual bool IsHigherRank(SkillName skillName, AccountType accountType, string userNameOne, string userNameTwo)
        {
            var skillOne = GetSkill(skillName, accountType, userNameOne);
            var skillTwo = GetSkill(skillName, accountType, userNameOne);
            return IsHigherRank(skillOne, skillTwo);
        }

        public bool IsLowerRank(SkillVersion skillVersionOne, SkillVersion skillVersionTwo)
        {
            var isHigher = false;
            if (skillVersionOne.Rank > skillVersionTwo.Rank)
            {
                return isHigher;
            }
            else
            {
                isHigher = true;
            }

            return isHigher;
        }

        public virtual bool IsLowerRank(SkillName skillName, AccountType accountType, string userNameOne, string userNameTwo)
        {
            var skillOne = GetSkill(skillName, accountType, userNameOne);
            var skillTwo = GetSkill(skillName, accountType, userNameOne);
            return IsLowerRank(skillOne, skillTwo);
        }

    }
}
