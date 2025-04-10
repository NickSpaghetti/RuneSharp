using RuneSharp.Enums;
using RuneSharp.Models.AccountTypes.OsRs;
using RuneSharp.Models.Skills;
using RuneSharp.Querying.Hiscores.AccountHiscores.OsRs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuneSharp.Querying.Hiscores.Skills.OsRs
{
    public class OsRsSkillsHiscoreQuerying : SkillsHiscoresQuerying<OsRsSkill>
    {
        public override OsRsSkill GetSkill(SkillName skillName, AccountType accountType, string userName)
        {
            return ResolveAccountType(accountType, userName).Skills.FirstOrDefault(s => s.Name == skillName);
        }


        private OsRsBaseAccount ResolveAccountType(AccountType accountType, string username)
        {
            var query = new OsRsHiscoresAccountQuerying();
            switch (accountType)
            {
                case AccountType.Standard:
                    return query.osRsStandardHiscores.SingleAccount(username);
                case AccountType.Ironman:
                    return query.osRsIronmanHiscores.SingleAccount(username);
                case AccountType.HardcoreIronman:
                    return query.osRsHardcoreIronmanHiscores.SingleAccount(username);
                case AccountType.UltimateIronman:
                    return query.osRsUltimateIronmanHiscores.SingleAccount(username);
                case AccountType.Seasonal:
                    return query.osRsSeasonalHiscores.SingleAccount(username);
                case AccountType.Tournament:
                    return query.osRsDeadmanModeHiscores.SingleAccount(username);
                case AccountType.DeadmanMode:
                    return query.osRsDeadmanModeHiscores.SingleAccount(username);
                default:
                    return query.osRsStandardHiscores.SingleAccount(username);

            }
        }
    }
}
