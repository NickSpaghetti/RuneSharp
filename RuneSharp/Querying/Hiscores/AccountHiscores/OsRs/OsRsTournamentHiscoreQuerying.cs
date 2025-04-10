using RuneSharp.Constants;
using RuneSharp.Helpers.ParsersHelper.HiscoreParsers.OsRs;
using RuneSharp.Helpers.RESTHelpers;
using RuneSharp.Models.AccountTypes.OsRs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Querying.Hiscores.AccountHiscores.OsRs
{
    public class OsRsTournamentHiscoreQuerying : HiscoreQuerying<OsRsTournamentAccount>
    {
        public override OsRsTournamentAccount SingleAccount(string username)
        {
            var stanardRank = GetRequestHiscoreHelper.GetAccountHiscoreRank(OsRsConstants.URIConstants.HiscoreConstants.Standard, username);
            var ironResult = GetRequestHiscoreHelper.GetAccountHiscores(OsRsConstants.URIConstants.HiscoreConstants.Tourdment, username);
            var parsedTournament = OsRsHiscoreAccountParser<OsRsTournamentAccount>.ParseAccount(username, ironResult);
            parsedTournament.TournamentRank = parsedTournament.OverAllRank;
            parsedTournament.OverAllRank = stanardRank;

            return parsedTournament;
        }
    }
}
