using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsUltimateIronmanQuerying : HiscoreQuerying<OsRsUltimateIronmanAccount>
    {
        public override OsRsUltimateIronmanAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            var ironResult = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.UlitmateIronman, username);
            var parsedIron = OsRsHiscoreAccountParser<OsRsUltimateIronmanAccount>.ParseAccount(username, ironResult);
            parsedIron.UlitmateRank = parsedIron.OverAllRank;
            parsedIron.OverAllRank = stanardRank;

            return parsedIron;
        }

    }
}
