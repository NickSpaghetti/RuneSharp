using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsHiscoresAccountQuerying
    {
        public OsRsStandardHiscoreQuerying osRsStandardHiscores;
        public OsRsIronmanHiscoreQuerying osRsIronmanHiscores;
        public OsRsHardcoreIronmanQuerying osRsHardcoreIronmanHiscores;
        public OsRsUltimateIronmanQuerying osRsUltimateIronmanHiscores;
        public OsRsDeadmanModeQuerying osRsDeadmanModeHiscores;
        public OsRsSeasonalHiscoreQuerying osRsSeasonalHiscores;
        public OsRsTournamentHiscoreQuerying osRsTournamentHiscores;
        public OsRsHiscoresAccountQuerying()
        {
            osRsStandardHiscores = new OsRsStandardHiscoreQuerying();
            osRsIronmanHiscores = new OsRsIronmanHiscoreQuerying();
            osRsHardcoreIronmanHiscores = new OsRsHardcoreIronmanQuerying();
            osRsUltimateIronmanHiscores = new OsRsUltimateIronmanQuerying();
            osRsDeadmanModeHiscores = new OsRsDeadmanModeQuerying();
            osRsSeasonalHiscores = new OsRsSeasonalHiscoreQuerying();
            osRsTournamentHiscores = new OsRsTournamentHiscoreQuerying();
        }
    }
}
