using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsDeadmanModeQuerying : HiscoreQuerying<OsRsDeadmanAccount>
    {
        public override OsRsDeadmanAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            var deadResult = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.DeadmanMode, username);
            var parsedDead = OsRsHiscoreAccountParser<OsRsDeadmanAccount>.ParseAccount(username, deadResult);
            parsedDead.DeadmanRank = parsedDead.OverAllRank;
            parsedDead.OverAllRank = stanardRank;
            return parsedDead;
        }
    }
}
