using RuneSharp.Querying.Bestary.OsRs;
using RuneSharp.Querying.GrandExchange.OsRs;
using RuneSharp.Querying.Hiscores.AccountHiscores.OsRs;
using RuneSharp.Querying.Hiscores.Skills.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying
{
    public class OsRsQuerying
    {
        public OsRsHiscoresAccountQuerying osrsHiscoresQuerying;
        public OsRsSkillsHiscoreQuerying osRsSkillsHiscoresQuerying;
        public OsRsGrandExchangeQuerying osRsGrandExchangeQuerying;
        public OsRsBeastaryQuerying osRsBeastaryQuerying;
        public OsRsQuerying()
        {
            osrsHiscoresQuerying = new OsRsHiscoresAccountQuerying();
            osRsSkillsHiscoresQuerying = new OsRsSkillsHiscoreQuerying();
            osRsGrandExchangeQuerying = new OsRsGrandExchangeQuerying();
            osRsBeastaryQuerying = new OsRsBeastaryQuerying();
        }
    }
}
