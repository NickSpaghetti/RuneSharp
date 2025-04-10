using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsIronmanHiscoreQuerying : HiscoreQuerying<OsRsIronmanAccount>
    {
        public override OsRsIronmanAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            var ironResult = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.Ironman, username);
            var parsedIron = OsRsHiscoreAccountParser<OsRsIronmanAccount>.ParseAccount(username, ironResult);
            parsedIron.IronmanRank = parsedIron.OverAllRank;
            parsedIron.OverAllRank = stanardRank;

            return parsedIron;
        }
    }
}
