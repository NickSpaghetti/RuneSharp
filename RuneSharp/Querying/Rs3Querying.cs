using RuneSharp.Querying.Bestary.Rs3;
using RuneSharp.Querying.GrandExchange.Rs3;
using RuneSharp.Querying.Hiscores.AccountHiscores.Rs3;
using RuneSharp.Querying.Hiscores.Clans.Rs3;
using RuneSharp.Querying.Hiscores.Runemetrics.Rs3;
using RuneSharp.Querying.Hiscores.Skills.Rs3;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying
{
    public class Rs3Querying
    {
        public Rs3HiscoresAccountQuerying rs3HiscoreQuerying;
        public Rs3ClanQuerying rs3ClanQuerying;
        public Rs3SkillsHiscoreQuerying rs3SkillsQuerying;
        public Rs3GrandExchangeQuerying rs3GrandExchangeQuerying;
        public Rs3RunemetricsQuerying rs3RunemetricsQuerying;
        public Rs3BeastaryQuerying rs3BeastaryQuerying;
        public Rs3Querying()
        {
            rs3HiscoreQuerying = new Rs3HiscoresAccountQuerying();
            rs3ClanQuerying = new Rs3ClanQuerying();
            rs3SkillsQuerying = new Rs3SkillsHiscoreQuerying();
            rs3GrandExchangeQuerying = new Rs3GrandExchangeQuerying();
            rs3RunemetricsQuerying = new Rs3RunemetricsQuerying();
            rs3BeastaryQuerying = new Rs3BeastaryQuerying();
        }
    }
}
