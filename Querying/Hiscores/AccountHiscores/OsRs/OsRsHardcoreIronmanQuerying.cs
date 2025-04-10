using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsHardcoreIronmanQuerying : HardcoreHiscoreQuerying<OsRsHardcoreIronmanAccount>
    {
        public override OsRsHardcoreIronmanAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            var hardcoreResult = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.HardcoreIronman, username);
            var parsedHardcore = OsRsHiscoreAccountParser<OsRsHardcoreIronmanAccount>.ParseAccount(username, hardcoreResult);
            parsedHardcore.HardcoreRank = parsedHardcore.OverAllRank;
            parsedHardcore.OverAllRank = stanardRank;
            parsedHardcore.IsDead = IsAccountEliminated(parsedHardcore);

            return parsedHardcore;
        }
    }
}
