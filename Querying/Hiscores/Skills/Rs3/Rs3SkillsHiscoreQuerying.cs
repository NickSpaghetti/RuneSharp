using RuneSharp.Constants;
using RuneSharp.Enums;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes;
using RuneSharp.Models.AccountTypes.Rs3;
using RuneSharp.Models.Skills;
using RuneSharp.Querying.Hiscores.AccountHiscores.Rs3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Skills.Rs3
{
    public class Rs3SkillsHiscoreQuerying : SkillsHiscoresQuerying<Rs3Skill>
    {
        public override Rs3Skill GetSkill(SkillName skillName, AccountType accountType, string userName)
        {
            return ResolveAccountType(accountType,userName).Skills.FirstOrDefault(s => s.Name == skillName);
        }


        public Dictionary<string,Rs3Skill> GetTopSkills(SkillName skillName, int numberOfPlayers = Rs3Constants.URIConstants.SkillHiscoreConstants.SkillHiscoreDataMembers.MaxUsers)
        {
            var SkillList = new List<Rs3Skill>();
            if(numberOfPlayers > Rs3Constants.URIConstants.SkillHiscoreConstants.SkillHiscoreDataMembers.MaxUsers || numberOfPlayers <= 0)
            {
                numberOfPlayers = Rs3Constants.URIConstants.SkillHiscoreConstants.SkillHiscoreDataMembers.MaxUsers;
            }

            return GetRequestSkillHelper.GetTopFiftyRankedSkills(skillName, numberOfPlayers);
        }
      

        private Rs3BaseAccount ResolveAccountType(AccountType accountType, string username)
        {
            var query = new Rs3HiscoresAccountQuerying();
            switch(accountType)
            {
                case AccountType.Standard:
                    return query.rs3StandardHiscores.SingleAccount(username);
                case AccountType.Ironman:
                    return query.rs3IronmanHiscores.SingleAccount(username);
                case AccountType.HardcoreIronman:
                    return query.rs3HardcoreIronmanHiscores.SingleAccount(username);
                default:
                    return query.rs3StandardHiscores.SingleAccount(username);

            }
        }
    }
}
