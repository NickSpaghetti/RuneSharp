using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsSeasonalHiscoreQuerying : HiscoreQuerying<OsRsSeasonalAccount>
    {
        public override OsRsSeasonalAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            var seasonalResult = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.Seasonal, username);
            var parsedSeason = OsRsHiscoreAccountParser<OsRsSeasonalAccount>.ParseAccount(username, seasonalResult);
            parsedSeason.SeasonalRank = parsedSeason.OverAllRank;
            parsedSeason.OverAllRank = stanardRank;

            return parsedSeason;
        }
    }
}
