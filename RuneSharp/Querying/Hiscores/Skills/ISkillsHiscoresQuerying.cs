using RuneSharp.Enums;
using RuneSharp.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Skills
{
    public interface ISkillsHiscoresQuerying<SkillVersion> where SkillVersion : ISkill
    {
        SkillVersion GetSkill(SkillName skillName, AccountType accountType, string userName);
        bool IsHigherRank(SkillName skillName, AccountType accountType, string userNameOne, string userNameTwo);
        bool IsLowerRank(SkillName skillName, AccountType accountType, string userNameOne, string userNameTwo);
        bool IsHigherRank(SkillVersion skillVersionOne, SkillVersion skillVersionTwo);
        bool IsLowerRank(SkillVersion skillVersionOne, SkillVersion skillVersionTwo);
    }
}
